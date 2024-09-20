using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4)
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
    }
}
