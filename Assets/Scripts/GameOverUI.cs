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
    
    public void ShowInterface() {
        this.UpdateUI();
        this.gameOverImage.SetActive(true);
    }

    public void HideInterface() {
        this.gameOverImage.SetActive(false);
    }

    private void UpdateUI() {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreValue.text = highscore.ToString();
    }
}
