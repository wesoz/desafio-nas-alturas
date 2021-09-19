using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatePlayerWIthAnimation : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onFinishAnimation;
    public void ActivatePlayer() {
        this.onFinishAnimation.Invoke();
    }
}
