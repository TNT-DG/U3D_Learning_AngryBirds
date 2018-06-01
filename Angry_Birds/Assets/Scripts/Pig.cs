using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed=10;
    public float minSpeed = 5;
    private SpriteRenderer render;
    public Sprite hurt;

    private void Awake()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("速度"+collision.relativeVelocity.magnitude);
        //速度大直接死亡
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Destroy(gameObject);
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude <= maxSpeed)
        {
            render.sprite = hurt;
        }
    }

}
