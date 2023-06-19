using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour {
    public int ScoreVaule;
    public GameObject Explosion;

    public void Kill() {
        AliensMasters.allAliens.Remove(gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}