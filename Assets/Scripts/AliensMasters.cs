using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensMasters : MonoBehaviour {

    public GameObject BulletPrefab, MotherShipPreFab;
    private Vector3 HMoveDis = new Vector3(0.05f, 0, 0), VMoveDis = new Vector3(0, 0.25f, 0), MotherShipSpawnPoint = new Vector3(12f, 3.75f, 0);
    private float MaxLeft = -8.2f, MaxRight = 8.2f, MoveTimer = 0.01f, MoveTime = 0.002f, MaxMoveSpeed = 0.02f, ShootTimer = 2f, ShootTime = 2f;
    private float MotherShipTimer = 30f, MotherShipMinTime = 15f, MotherShipMaxTimer = 30f, StartY = 1.5f;
    public static List<GameObject> allAliens = new List<GameObject>();
    private bool MovingRight;
    private bool Entering = true;

    void Start() {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
            allAliens.Add(go);
    }

    void Update() {
        if (Entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);

            if (transform.position.y <= StartY)
                Entering = false;
        }
        else
        {
            if (MoveTimer <= 0)
                    MoveAliens();

            if (ShootTimer <= 0)
                    Shoot();
            if (MotherShipTimer <= 0)
                    SpawnMotherShip();

            MoveTimer -= Time.deltaTime;
            ShootTimer -= Time.deltaTime;
            MotherShipTimer -= Time.deltaTime;
        }
       
    }

    private void MoveAliens() {
        if (allAliens.Count > 0) {
            int HitMax = 0;

            for (int i = 0; i < allAliens.Count; i++) {
                if (MovingRight)
                    allAliens[i].transform.position += HMoveDis;
                else
                    allAliens[i].transform.position -= HMoveDis;

                if (allAliens[i].transform.position.x > MaxRight || allAliens[i].transform.position.x < MaxLeft)
                    HitMax++;
            }
            if(HitMax > 0) {
                for (int i = 0; i < allAliens.Count; i++)
                    allAliens[i].transform.position -= VMoveDis;

                MovingRight = !MovingRight;
            }

            MoveTimer = GetMoveSpeed();

        }
    }

    private float GetMoveSpeed() {
        float f = allAliens.Count * MoveTime;

        if (f < MaxMoveSpeed)
            return MaxMoveSpeed;
        else
            return f;
    }

    private void Shoot() {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;
        Instantiate(BulletPrefab, pos, Quaternion.identity);
        ShootTimer = ShootTime;
    }

    private void SpawnMotherShip() {
        Instantiate(MotherShipPreFab, MotherShipSpawnPoint, Quaternion.identity);
        MotherShipTimer = Random.Range(MotherShipMinTime, MotherShipMaxTimer);
    }
}