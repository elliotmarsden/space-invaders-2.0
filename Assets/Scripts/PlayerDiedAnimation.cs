using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedAnimation : MonoBehaviour {
    public float Delay;

    void Start() {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + Delay);
    }
}
