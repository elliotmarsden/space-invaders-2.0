using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensMasters : MonoBehaviour {

    public GameObject BulletPrefab;

    private Vector3 HMoveDis = new Vector3(0.05f, 0, 0);
    private Vector3 VMoveDis = new Vector3(0, 0.05f, 0);

    private float MaxLeft = -8.2f, MaxRight = 8.2f, MoveTimer = 0.01f, MoveTime = 0.002f, MaxMoveSpeed = 0.02f;

    public static List<GameObject> allAliens = new List<GameObject>();

    private bool MovingRight;

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
            allAliens.Add(go);
    }

    void Update()
    {
        if (MoveTimer <= 0)
            MoveAliens();

        MoveTimer -= Time.deltaTime;
    }

    private void MoveAliens()
    {
        if (allAliens.Count > 0)
        {
            int HitMax = 0;

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (MovingRight)
                    allAliens[i].transform.position += HMoveDis;
                else
                    allAliens[i].transform.position -= HMoveDis;

                if (allAliens[i].transform.position.x > MaxRight || allAliens[i].transform.position.x < MaxLeft)
                    HitMax++;
            }

            if(HitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                    allAliens[i].transform.position -= VMoveDis;

                MovingRight = !MovingRight;
            }

            MoveTimer = GetMoveSpeed();

        }
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * MoveTime;

        if (f < MaxMoveSpeed)
            return MaxMoveSpeed;
        else
            return f;
    }

}
