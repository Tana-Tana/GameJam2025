using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attribute", order = 0)]
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private Rigidbody2D rigit;
    public Rigidbody2D Rigit { get { return rigit; } set { rigit = value; } }

    [SerializeField] private float damage = 0;
    public float Damage { get { return damage; } set { damage = value; } }
    [SerializeField] private float speed = 0;
    public float Speed { get { return speed; } set { speed = value; } }
    [SerializeField] private Vector3 direction;
    public Vector3 Direction { get { return direction; } set { direction = value; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Đạn bắn trúng người chơi => endGame");
        }

        Messenger.Broadcast(EventKey.RELOAD_BULLET);
        //Debug.Log("Xét điều kiện tan biến đạn tùy khoảng cách");
    }
}
