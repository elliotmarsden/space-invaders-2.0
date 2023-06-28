using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject[] AllAlienSets;
   private GameObject CurrentSet;
   private Vector2 SpawnPos = new Vector2(0, 10);
   private static GameManager instance;

   private void Awake()
   {
        if (instance == null)
            instance = this;
        else 
            Destroy(gameObject);
   }

    private void Start()
    {
        SpawnNextWave();
    }

   public static void SpawnNextWave()
   {
    instance.StartCoroutine(instance.SpawnWave());
   }

   private IEnumerator SpawnWave()
   {
    if (CurrentSet != null)
    Destroy(CurrentSet);

    yield return new WaitForSeconds(6);

    CurrentSet = Instantiate(AllAlienSets[Random.Range(0, AllAlienSets.Length)], SpawnPos, Quaternion.identity);
    UIManager.UpdataWave();
   }
}
