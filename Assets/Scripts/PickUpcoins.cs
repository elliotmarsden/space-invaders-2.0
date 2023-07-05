using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpcoins : PickUp
{
    public override void PickMeUp()
    {
        inventory.currentCoins++;
        UIManager.UpdataCoins();
        Destroy(gameObject);
    }
}
