using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerDirector : Director
{
    [SerializeField]
    private int scoreToRevive;
    private Player[] players;
    private bool isAnyPlayerDead;
    private int scoreSinceDeath;
    private CanvasInactiveUI canvasInactiveUI;

    protected override void Start() {
        base.Start();
        this.players = GameObject.FindObjectsOfType<Player>();
        this.canvasInactiveUI = GameObject.FindObjectOfType<CanvasInactiveUI>();
    }

    public void ReviveIfNeeded() {
         if (this.isAnyPlayerDead) {
             this.scoreSinceDeath++;
             this.canvasInactiveUI.UpdateText(this.scoreToRevive - this.scoreSinceDeath);
             if (this.scoreSinceDeath >= scoreToRevive) {
                 this.canvasInactiveUI.Hide();
                 this.RevivePlayers();
             }
         }
    }

    public void RevivePlayers() {
        this.isAnyPlayerDead = false;
        foreach (Player player in this.players)
        {
            player.Activate();
        }
    }

    public void PlayerDied(Camera camera) {
        if (this.isAnyPlayerDead) {
            this.canvasInactiveUI.Hide();
            this.GameOver();
        } else {
            this.canvasInactiveUI.UpdateText(this.scoreToRevive);
            this.isAnyPlayerDead = true;
            this.scoreSinceDeath = 0;
            this.canvasInactiveUI.Show(camera);
        }
    }

    public override void RestartGame()
    {
        base.RestartGame();
        this.RevivePlayers();
    }
}
