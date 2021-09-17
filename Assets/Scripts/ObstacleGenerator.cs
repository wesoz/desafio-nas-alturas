using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private float timeToGenerate;
    [SerializeField]
    private GameObject obstaclePrefab;
    private float timer;
    private void Awake()
    {
        this.timer = this.timeToGenerate;
    }

    void Update () { 
        this.timer -= Time.deltaTime;
        if(this.timer < 0)
        {
            GameObject.Instantiate(this.obstaclePrefab, this.transform.position, Quaternion.identity);
            this.timer = this.timeToGenerate;
        }
    }
}
