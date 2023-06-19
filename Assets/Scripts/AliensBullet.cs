using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensBullet : MonoBehaviour {

    private float Speed = 7;
    void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

    }
}
