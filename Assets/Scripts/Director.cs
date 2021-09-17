using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverImage;
    private Airplane airplane;
    private Score score;

    private void Start() {
        this.airplane = GameObject.FindObjectOfType<Airplane>();
        this.score = GameObject.FindObjectOfType<Score>();
    }
    public void GameOver() {
        Time.timeScale = 0;
        this.gameOverImage.SetActive(true);
    }

    public void RestartGame() {
        this.gameOverImage.SetActive(false);
        Time.timeScale = 1;
        this.airplane.Restart();
        this.DestroyObstacles();
        this.score.Reset();
    }

    private void DestroyObstacles() {
        Obstacle[] obstables = GameObject.FindObjectsOfType<Obstacle>();
        foreach(Obstacle obstacle in obstables) {
            obstacle.Destroy();
        }
    }
}
