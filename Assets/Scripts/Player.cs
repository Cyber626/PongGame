using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float speed = GameManager.playerSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > -4)
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
    }
}
