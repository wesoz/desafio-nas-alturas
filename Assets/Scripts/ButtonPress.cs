using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    
    [SerializeField]
    private UnityEvent onKeyDown;

    void Update()
    {
        if (Input.GetKeyDown(this.key)) {
            this.onKeyDown.Invoke();
        }
    }
}
