using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : PickUp {

    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AddLives();
        Destroy(gameObject);
        
    }
}
