using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Carousel[] carousels;
    private ObstacleGenerator obstacleGenerator;

    private void Start() {
        this.carousels = this.GetComponentsInChildren<Carousel>();
        this.obstacleGenerator = this.GetComponentInChildren<ObstacleGenerator>();
    }

    public void Deactivate() {
        this.obstacleGenerator.Stop();
        foreach (var carousel in this.carousels)
        {
            carousel.enabled = false;
        }
    }
}
