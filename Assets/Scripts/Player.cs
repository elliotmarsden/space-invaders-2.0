using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject BulletPrefab;

    private const float MaxLeft = -2.6f;
    private const float MaxRight = 2.6f;

    private float Speed = 3;
    private float CoolDown = 0.5f;

    private bool isShooting;

    void Update() {
        if (Input.GetKey(KeyCode.A) && transform.position.x > MaxLeft)
            transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MaxRight)
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
