using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInactiveUI : MonoBehaviour
{
    [SerializeField]
    private GameObject background;

    [SerializeField]
    private Text scoreToReviveText;
    private Canvas canvas;

    private void Awake() {
        this.canvas = this.GetComponent<Canvas>();
    }

    public void Show(Camera camera) {
        this.background.SetActive(true);
        this.canvas.worldCamera = camera;
    }

    public void Hide() {
        this.background.SetActive(false);
    }

    public void UpdateText(int scoreToRevive) {
        this.scoreToReviveText.text = scoreToRevive.ToString();
    }
}
