using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player1Trans;
    [SerializeField] private Transform player2Trans;
    private Vector3 offset;
    private Vector3 velocity;
    private float smoothTime;

    private void Start()
    {
        offset = new Vector3(0f,0f,-10f);
        smoothTime = 0.25f;
        velocity = Vector3.zero;

    }

    private void Update()
    {
        Vector3 middlePoint = (player1Trans.position + player2Trans.position) / 2f;
        
        Vector3 targetPos = new Vector3(middlePoint.x + offset.x, offset.y, offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
