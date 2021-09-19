using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAI : MonoBehaviour
{
    private Airplane airplane;
    void Start()
    {
        this.airplane = this.GetComponent<Airplane>();
        StartCoroutine(this.Impulse());
    }

    private IEnumerator Impulse() {
        while(true) {
            yield return new WaitForSeconds(0.6f);
            this.airplane.DoImpulse();
        }
    }
}
