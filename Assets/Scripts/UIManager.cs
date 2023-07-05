using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI ScoreText , CoinText, WaveText , HighScoreText;
    private int Score, HighScore, Wave;

    public Image[] LifeSprites;
    private static UIManager instance;

    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void UpdataLives(int l) {
        foreach (Image i in instance.LifeSprites)
            i.color = instance.inactive;

        for (int i = 0;  i < l; i++) {
            instance.LifeSprites[i].color = instance.active;
        }
    }

    public static void UpdataScore(int s) {
        instance.Score += s;
        instance.ScoreText.text = instance.Score.ToString("000,000");
    }

    public void UpdataHighScore() {

    }

    public static void UpdataWave() {
        instance.Wave++;
        instance.WaveText.text = instance.Wave.ToString();
    }

    public  static void UpdataCoins() {
        instance.CoinText.text = inventory.currentCoins.ToString();
    }
}