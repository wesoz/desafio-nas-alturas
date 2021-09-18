using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultLevelControl : MonoBehaviour
{
    [SerializeField]
    private float timeToMaxDificultLevel;
    private float elapsedTime;
    public float DificultLevel { get; private set; }

    void Update()
    {
        this.elapsedTime += Time.deltaTime;
        this.DificultLevel = this.elapsedTime / this.timeToMaxDificultLevel;
        this.DificultLevel = Mathf.Min(1, this.DificultLevel);
    }

}
