using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text highscoreValue;
    
    [SerializeField]
    private GameObject gameOverImage;
    
    [SerializeField]
    private Image medalImage;
    
    [SerializeField]
    private Sprite goldMedalSprite;

    [SerializeField]
    private Sprite silverMedalSprite;

    [SerializeField]
    private Sprite brassMedalSprite;

    private Score score;
    private int highscore;

    private void Start() {
        this.score = GameObject.FindObjectOfType<Score>();
        this.gameOverImage.SetActive(false);
    }
    public void ShowInterface() {
        this.UpdateUI();
        this.gameOverImage.SetActive(true);
    }

    public void HideInterface() {
        this.gameOverImage.SetActive(false);
    }

    private void UpdateUI() {
        this.highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreValue.text = highscore.ToString();
        this.SetMedalColor();
    }

    private void SetMedalColor() {
        if (this.score.ScorePoints > this.highscore - 2) {
            this.medalImage.sprite = this.goldMedalSprite;
        } else if (this.score.ScorePoints >= this.highscore / 2) {
            this.medalImage.sprite = this.silverMedalSprite;
        } else {
            this.medalImage.sprite = this.brassMedalSprite;
        }
    }
}
