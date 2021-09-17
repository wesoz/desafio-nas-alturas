using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    private Vector3 inicialPosition;
    private float scaledImageSize;

    private void Awake() 
    {
        this.inicialPosition = this.transform.position;
        float imageSize = this.GetComponent<SpriteRenderer>().size.x;
        float imageScale = this.transform.localScale.x;
        this.scaledImageSize = imageSize * imageScale;
    }


    void Update() {
        float offset = Mathf.Repeat(this.velocity * Time.time, this.scaledImageSize);
        this.transform.position = this.inicialPosition + Vector3.left * offset;

    }
}
