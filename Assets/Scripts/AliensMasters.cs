using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensMasters : MonoBehaviour {

    public GameObject BulletPrefab;

    private Vector3 HMoveDis = new Vector3(0, 0, 0);
    private Vector3 VMoveDis = new Vector3(0, 0, 0);

    private float MaxLeft = -2.5f, MaxRight = 2.5f, MoveTimer = 0.01f, MoveTime = 0.005f;

    public static List<GameObject> allAliens = new List<GameObject>();

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
            allAliens.Add(go);
    }

    private void MoveAliens()
    {
        if(allAliens.Count > 0)
            for (int i = 0; i < allAliens.Count; i++)
            {

            }
    }
}
