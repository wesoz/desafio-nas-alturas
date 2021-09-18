using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody2D physics;
    private Director director;
    private Vector3 initialPosition;
    private bool shuoldTriggerImpulse;

    private void Awake() {
        this.physics = this.GetComponent<Rigidbody2D>();
        this.initialPosition = this.transform.position;
    }

    private void Start() {
        this.director = GameObject.FindObjectOfType<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            this.shuoldTriggerImpulse = true;
        }
    }

    private void FixedUpdate() {
        if (this.shuoldTriggerImpulse) {
            this.Impulse();
            this.shuoldTriggerImpulse = false;
        }
    }

    private void Impulse() {
        this.physics.velocity = Vector2.zero;
        this.physics.AddForce(Vector2.up * this.force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        this.physics.simulated = false;
        this.director.GameOver();
    }

    public void Restart() {
        this.physics.simulated = true;
        this.transform.position = this.initialPosition;
    }
}
