using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private float smoothTime;
    private Vector3 velocity;
    [SerializeField] private Transform target;
    private void Start()
    {
        offset = new Vector3(6.5f,0f,-10f);
        smoothTime = 0.25f;
        velocity = Vector3.zero;
    }

    private void Update()
    {
        // offset = new Vector3(a,b,c);
        // Vector3 targetPos = target.position + offset;
        Vector3 targetPos = new Vector3(target.position.x + offset.x, offset.y, offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
