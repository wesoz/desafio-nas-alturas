using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private SharedPropertyFloat velocity;
    [SerializeField]
    private float variationY;

    private void Awake() {
        this.transform.Translate(Vector3.up * Random.Range(-variationY, variationY));
    }

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocity.value * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("ObstacleDestructor")) {
            this.Destroy();
        }
    }

    public void Destroy() {
        GameObject.Destroy(this.gameObject);
    }
}
