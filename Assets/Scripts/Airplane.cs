using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Airplane : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField]
    private UnityEvent onCollide;
    private Rigidbody2D physics;
    private Director director;
    private Vector3 initialPosition;
    private bool shuoldTriggerImpulse;
    private Animator airplaneAnimation;

    private void Awake() {
        this.physics = this.GetComponent<Rigidbody2D>();
        this.initialPosition = this.transform.position;
        this.airplaneAnimation = this.GetComponent<Animator>();
    }

    private void Start() {
        this.director = GameObject.FindObjectOfType<Director>();
    }

    void Update()
    {
        this.airplaneAnimation.SetFloat("VelocityY", this.physics.velocity.y);
    }

    private void FixedUpdate() {
        if (this.shuoldTriggerImpulse) {
            this.Impulse();
            this.shuoldTriggerImpulse = false;
        }
    }

    public void DoImpulse() {
        this.shuoldTriggerImpulse = true;
    }

    private void Impulse() {
        this.physics.velocity = Vector2.zero;
        this.physics.AddForce(Vector2.up * this.force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        this.physics.simulated = false;
        this.onCollide.Invoke();
    }

    public void Restart() {
        this.physics.simulated = true;
        this.transform.position = this.initialPosition;
    }
}
