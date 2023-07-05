using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : PickUp {

    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<Player>().AddLives();
        Destroy(gameObject);
        
    }
}
