using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float xForce, yForce;
    [SerializeField] private GameManager manager;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(StartFromCenter());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTrigger")
        {
            manager.EnemyScored();
        }
        else if (collision.tag == "EnemyTrigger")
        {
            manager.PlayerScored();
        }
        StartCoroutine(StartFromCenter());
    }

    private IEnumerator StartFromCenter()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;

        float xDir = UnityEngine.Random.value - .5f;
        float yDir = UnityEngine.Random.value - .5f;

        yield return new WaitForSeconds(.5f);

        rb.AddForce(new Vector2(xForce * Mathf.Sign(xDir), yForce * Mathf.Sign(yDir)));
    }
}
