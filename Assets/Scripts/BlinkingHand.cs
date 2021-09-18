using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingHand : MonoBehaviour
{
    private SpriteRenderer image;

    private void Awake() {
        this.image = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            this.Hide();
        }
    }

    private void Hide() {
        this.image.enabled = false;
    }
}
