using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour {

    public int ScoreVaule;
    private float MaxLeft = -12f, Speed = 5f;


    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);

        if (transform.position.x <= MaxLeft)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            UIManager.UpdataScore(ScoreVaule);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }
}
