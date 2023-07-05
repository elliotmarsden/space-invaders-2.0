using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerStats PlayerStats;
    public GameObject BulletPrefab;
    private Vector2 OffScreenPos = new Vector2(0, -20f);
    private Vector2 StartPos = new Vector2(0, -3.33f);
    private float MaxLeft = -8f, MaxRight = 8f;

    private bool isShooting;

    private void Start() {
        PlayerStats.CurrentHealth = PlayerStats.MaxHealth;
        PlayerStats.currentLives = PlayerStats.MaxLives;

        transform.position = StartPos;

        UIManager.UpdataLives(PlayerStats.currentLives);
    }

    void Update() {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > MaxLeft)
            transform.Translate(Vector2.left * Time.deltaTime * PlayerStats.PlayerSpeed);

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))&& transform.position.x < MaxRight)
            transform.Translate(Vector2.right * Time.deltaTime * PlayerStats.PlayerSpeed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    private void TakeDamage() {
        PlayerStats.CurrentHealth --;
        if (PlayerStats.CurrentHealth <= 0) {
            PlayerStats.currentLives --;
            UIManager.UpdataLives(PlayerStats.currentLives);

            if(PlayerStats.currentLives <= 0){
                Debug.Log("GAME OVER");
            }
            else {
                Debug.Log("RESPAWN");
                StartCoroutine(Respawn());
            }
        }
    }

    public void AddLives() {
        if (PlayerStats.currentLives == PlayerStats.MaxLives)
        {
            UIManager.UpdataScore(1000);
        }
        else
        {
            PlayerStats.currentLives++;
            UIManager.UpdataLives(PlayerStats.currentLives);
        }
    }

    private IEnumerator Shoot() {
        isShooting = true;
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(PlayerStats.FireRate);
        isShooting = false;
    }

    private IEnumerator Respawn() {
        transform.position = OffScreenPos; 
        yield return new WaitForSeconds(2);
        PlayerStats.CurrentHealth = PlayerStats.MaxHealth;
        transform.position = StartPos;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("AliensBullet")) {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
