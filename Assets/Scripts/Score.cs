using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int score = 0;
    private AudioSource scoreSound;

    private void Awake() {
        this.scoreSound = this.GetComponent<AudioSource>();
    }
    public void AddScore() {
        this.score++;
        this.scoreText.text = this.score.ToString();
        this.scoreSound.Play();
    }

    public void Reset() {
        this.score = 0;
        this.scoreText.text = this.score.ToString();
    }
}
