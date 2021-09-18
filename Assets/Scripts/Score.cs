using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    public int ScorePoints { get; private set; }
    private AudioSource scoreSound;

    private void Awake() {
        this.scoreSound = this.GetComponent<AudioSource>();
    }
    public void AddScore() {
        this.ScorePoints++;
        this.scoreText.text = this.ScorePoints.ToString();
        this.scoreSound.Play();
    }

    public void SaveHighscore() {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if (this.ScorePoints > highscore) {
            PlayerPrefs.SetInt("highscore", this.ScorePoints);
        }
    }
    public void Reset() {
        this.ScorePoints = 0;
        this.scoreText.text = this.ScorePoints.ToString();
    }
}
