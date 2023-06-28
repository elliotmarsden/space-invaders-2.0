using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    private float Speed = 10f;

    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Alien"))
        {
            collision.gameObject.GetComponent<Aliens>().Kill();
            Destroy(gameObject);
        }

        int chance = Random.Range(0, 100);
        if (chance >= 50)
        {
            if(collision.gameObject.CompareTag("AliensBullet"))
            {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
            }
        }
    
    }
}
