using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAI : MonoBehaviour
{
    enum PlayerAction {
        GoUp,
        GoDown,
        None,
    }

    struct ImpulseDelay {
        public static float Rapid { get { return 0.3f; } }
        public static float Slow { get { return 0.8f; } }
        public static float ReactionTime { get { return 0.1f; } }
        public static float Stabilize { get { return 0.6f; } }
    }

    private Airplane airplane;
    PlayerAction playerAction;
    Coroutine playerActionCoroutine;
    
    private void Awake() {
        this.playerAction = PlayerAction.None;
    }
    void Start()
    {
        this.airplane = this.GetComponent<Airplane>();
        this.playerActionCoroutine = StartCoroutine(this.Impulse());
    }

    private float GetDelayFromPlayerAction() {
        if (this.playerAction == PlayerAction.None) {
            return ImpulseDelay.Stabilize;
        } else if (this.playerAction == PlayerAction.GoUp) {
            return ImpulseDelay.Rapid;
        } else if (this.playerAction == PlayerAction.GoDown) {
            return ImpulseDelay.Slow;
        }

        return ImpulseDelay.ReactionTime;
    }

    private IEnumerator Impulse() {
        while(true) {
            float delay = this.GetDelayFromPlayerAction();
            
            yield return new WaitForSeconds(delay);
            
            this.airplane.DoImpulse();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("bottomAvoidArea") || other.CompareTag("topAvoidArea")) {
            this.playerAction = PlayerAction.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("bottomAvoidArea")) {
            this.playerAction = PlayerAction.GoUp;
        } else if (other.CompareTag("topAvoidArea")) {
            this.playerAction = PlayerAction.GoDown;
        }
    }

    public void Restart() {
        this.playerAction = PlayerAction.None;
    }
}
