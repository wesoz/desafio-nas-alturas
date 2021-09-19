using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAI : MonoBehaviour
{
    [SerializeField]
    private float impulseDelay;

    private Airplane airplane;
    void Start()
    {
        this.airplane = this.GetComponent<Airplane>();
        StartCoroutine(this.Impulse());
    }

    private IEnumerator Impulse() {
        while(true) {
            yield return new WaitForSeconds(this.impulseDelay);
            this.airplane.DoImpulse();
        }
    }
}
