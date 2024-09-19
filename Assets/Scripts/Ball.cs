using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float xForce, yForce;
    [SerializeField] private GameObject obstacle;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        float xDir = UnityEngine.Random.value - .5f;
        float yDir = UnityEngine.Random.value - .5f;

        rb.AddForce(new Vector2(xForce * Mathf.Sign(xDir), yForce * Mathf.Sign(yDir)));
    }
}
