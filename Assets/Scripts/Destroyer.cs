using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "AliensBullet") {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Coins") {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "CoinsLives") {
            Destroy(collision.gameObject);  
        }
    }
}
