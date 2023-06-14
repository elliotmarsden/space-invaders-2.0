using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    private float Speed = 10f;

    void Update() {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }
}
