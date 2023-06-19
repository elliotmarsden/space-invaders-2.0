using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats {
    [Range(1,5)]
    public int MaxHealth;
    [HideInInspector]
    public int CurrentHealth;
    [HideInInspector]
    public int MaxLives = 3;
    [HideInInspector]
    public int currentLives = 3;

    public float PlayerSpeed;
    public float FireRate;
}
