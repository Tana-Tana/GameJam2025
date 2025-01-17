using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour, IEnemy
{
    [Header("Element", order = 0)]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigitbody2d;


    [Header("Movement", order = 1)]
    [SerializeField] private float speed = 0;
    [SerializeField] private int direction = 1;

    [Header("Bullet", order = 2)]
    [SerializeField] private Bullet bullet;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private int amout_bullet = 1;
    [SerializeField] private float timeBetweenFire = 2f;

    // private
    private float _fireCountDown = 0;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigitbody2d = GetComponent<Rigidbody2D>();
        bulletPool = new BulletPool();
    }

    private void Start()
    {
        GenerateBulletToBulletPool(bullet);
    }

    private void GenerateBulletToBulletPool(Bullet bullet)
    {
        for (int i = 1; i <= amout_bullet; i++)
        {
            Bullet obj = Instantiate(bullet, transform.position, Quaternion.identity);
            obj.gameObject.SetActive(false);
            bulletPool.AddBullet(obj);
        }
    }

    private void Update()
    {
        Shooting();
        Move();
    }

    private void Shooting()
    {
        _fireCountDown -= Time.deltaTime;
        if (_fireCountDown < 0 )
        {
            _fireCountDown = timeBetweenFire;
            Bullet obj = bulletPool.GetBullet();
            obj.gameObject.SetActive(true);

            Vector3 playerPos = FindObjectOfType<Player>().transform.position; // lấy vị trí nhân vật
            obj.Direction = playerPos - transform.position; // lấy hướng bắn
            obj.Rigit.AddForce(obj.Direction.normalized * obj.Speed, ForceMode2D.Impulse);
        }
    }

    public void Move()
    {
        Debug.Log("Xét điều kiện đổi hướng follow theo nhân vật");
        Vector3 playerPos = FindObjectOfType<Player>().transform.position; // lấy vị trí nhân vật
        if(playerPos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kẻ địch chạm vào người chơi => EndGame");
        }
        
    }
}
