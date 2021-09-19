using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private float timeToGenerateEasy;
    [SerializeField]
    private float timeToGenerateHard;
    [SerializeField]
    private GameObject obstaclePrefab;
    private DificultLevelControl dificultLevelControl;
    private float timer;
    private bool isStoped;
    private void Awake()
    {
        this.timer = this.timeToGenerateEasy;
    }

    private void Start() {
        this.dificultLevelControl = GameObject.FindObjectOfType<DificultLevelControl>();
    }

    private void Update () { 
        if (this.isStoped) {
            return;
        }

        this.timer -= Time.deltaTime;
        if(this.timer < 0)
        {
            GameObject.Instantiate(this.obstaclePrefab, this.transform.position, Quaternion.identity);
            this.timer = Mathf.Lerp(this.timeToGenerateEasy, 
                                    this.timeToGenerateHard, 
                                    this.dificultLevelControl.DificultLevel) ;
        }
    }

    public void Stop() {
        this.isStoped = true;
    }

    public void Resume() {
        this.isStoped = false;
    }
}
