using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour {
    public int ScoreVaule, LivesChance = 50, CoinChance = 500;
    public GameObject Explosion, CoinPrefab, LivesPrefab;

    public void Kill() {
        UIManager.UpdataScore(ScoreVaule);
        AliensMasters.allAliens.Remove(gameObject);

        int ran = Random.Range(0, 1000);
        if (ran == LivesChance)
            Instantiate(LivesPrefab, transform.position, Quaternion.identity);
        else if (ran <= CoinChance)
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);

        Instantiate(Explosion, transform.position, Quaternion.identity);
        if (AliensMasters.allAliens.Count == 0)
            GameManager.SpawnNextWave();
        Destroy(gameObject);
    }
}