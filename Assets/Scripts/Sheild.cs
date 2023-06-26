using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour {
    public Sprite[] states;

    private int Health;
    private SpriteRenderer sr;

    void Start() {
        Health = 3;
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AliensBullet"))
        {
            Destroy(collision.gameObject);
            Health--;

            if (Health < 1)
                Destroy(gameObject);
            else
                sr.sprite = states[Health - 1];
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
