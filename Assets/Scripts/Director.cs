using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    private Airplane airplane;
    private Score score;
    private GameOverUI gameOverUI;

    private void Start() {
        this.airplane = GameObject.FindObjectOfType<Airplane>();
        this.score = GameObject.FindObjectOfType<Score>();
        this.gameOverUI = GameObject.FindObjectOfType<GameOverUI>();
    }
    public void GameOver() {
        Time.timeScale = 0;
        this.score.SaveHighscore();
        this.gameOverUI.ShowInterface();
    }

    public void RestartGame() {
        this.gameOverUI.HideInterface();
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
