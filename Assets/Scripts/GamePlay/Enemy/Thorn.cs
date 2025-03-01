﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour, IEnemy
{
    [Header("Element", order = 0)]
    [SerializeField] private EdgeCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigitbody2d;


    [Header("Movement", order = 1)]
    [SerializeField] private float speed = 0;
    [SerializeField] private Vector3 direction = Vector3.down;


    // Public
    public bool canMove = false;

    private void Awake()
    {
        boxCollider = GetComponent<EdgeCollider2D>();
        rigitbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetSpeed();
        Move();
    }

    private void SetSpeed()
    {
        speed = (canMove) ? 1f : 0f;
    }

    public void Move()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Messenger.Broadcast(EventKey.ENDGAME);
            Debug.Log("Gai đâm trúng nhân vật => EndGame");
        }
        else
        {
            direction *= -1;
        }
    }
}
