using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject BulletPrefab;

    public float MaxLeft = -8.5f, MaxRight = 8.5f, Speed = 3, CoolDown = 0.5f;

    private bool isShooting;

    void Update() {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > MaxLeft)
            transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))&& transform.position.x < MaxRight)
            transform.Translate(Vector2.right * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    private IEnumerator Shoot() {
        isShooting = true;
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(CoolDown);
        isShooting = false;
    }
}
