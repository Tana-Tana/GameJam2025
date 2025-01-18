using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBar : MonoBehaviour
{

    [Header("Movement", order = 1)]
    [SerializeField] private float speed = 0;
    [SerializeField] private Vector3 direction = Vector3.left;


    // Public
    public bool canMove = false;

    private void Update()
    {
        if (transform.position.x < 81f)
            direction = Vector3.right;
        else if (transform.position.x > 93f)
            direction = Vector3.left;
        SetSpeed();
        Move();
    }

    private void SetSpeed()
    {
        speed = (canMove) ? 3f : 0f;
    }

    public void Move()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null, true);
        }
    }
}
