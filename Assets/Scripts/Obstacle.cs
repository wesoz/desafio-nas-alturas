using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private SharedPropertyFloat velocity;
    [SerializeField]
    private float variationY;
    private Vector3 airplanePosition;
    private bool scored = false;
    private Score score;

    private void Awake() {
        this.transform.Translate(Vector3.up * Random.Range(-variationY, variationY));
    }

    private void Start() {
        this.airplanePosition = GameObject.FindObjectOfType<Airplane>().transform.position;
        this.score = GameObject.FindObjectOfType<Score>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * this.velocity.value * Time.deltaTime);
        if (!this.scored && this.transform.position.x < this.airplanePosition.x) {
            this.score.AddScore();
            this.scored = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        this.Destroy();
    }

    public void Destroy() {
        GameObject.Destroy(this.gameObject);
    }
}
