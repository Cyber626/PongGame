using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [NonSerialized] public Ball ball;
    public float speed;

    private void Update()
    {
        if (transform.position.y > -4 && transform.position.y < 4)
        {
            float dir = ball.transform.position.y - transform.position.y;

            transform.position += Mathf.Sign(dir) * speed * Time.deltaTime * Vector3.up;
        }
    }

}
