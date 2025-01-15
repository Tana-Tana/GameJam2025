using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed = 0;

    void Start()
    {
        
    }

    private void Update()
    {
        move();
    }

    public void move()
    {
        speed = 0;
    }
}
