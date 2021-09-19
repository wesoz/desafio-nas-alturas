using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Carousel[] carousels;
    private ObstacleGenerator obstacleGenerator;
    private Airplane airplane;
    private bool isActive;

    private void Start() {
        this.carousels = this.GetComponentsInChildren<Carousel>();
        this.obstacleGenerator = this.GetComponentInChildren<ObstacleGenerator>();
        this.airplane = this.GetComponentInChildren<Airplane>();
        this.isActive = true;
    }

    public void Activate() {
        if (!this.isActive) {
            this.isActive = true;
            this.airplane.Restart();
            this.obstacleGenerator.Resume();
            foreach (var carousel in this.carousels)
            {
                carousel.enabled = true;
            }            
        }
    }

    public void Deactivate() {
        this.isActive = false;
        this.obstacleGenerator.Stop();
        foreach (var carousel in this.carousels)
        {
            carousel.enabled = false;
        }
    }
}
