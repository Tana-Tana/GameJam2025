using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour, IEnemy
{
    [Header("Element", order = 0)]
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private AnimationClip animationClip;

    [Header("Movement", order = 1)]
    [SerializeField] private Vector3 direction = Vector3.left;

    [Header("Bullet", order = 2)]
    [SerializeField] private Bullet bullet;
    [SerializeField] private float timeBetweenFire = 2f;

    // private
    private float _fireCountDown = 2;
    private Bullet _bullet = null;

    // public
    public bool checkShootFollowPlayer = false;
    public bool checkShoot = false;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        timeBetweenFire = animationClip.length;
        _fireCountDown = animationClip.length;
    }

    private void Start()
    {
        GenerateBulletToBulletPool(bullet);
    }

    private void GenerateBulletToBulletPool(Bullet bullet)
    {
        _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        Messenger.AddListener(EventKey.RELOAD_BULLET, ReloadBullet);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.RELOAD_BULLET, ReloadBullet);
    }

    private void ReloadBullet()
    {
        _bullet.gameObject.SetActive(false);
        _bullet.transform.position = transform.position;
    }

    private void Update()
    {
        if (checkShootFollowPlayer)
        {
            Move();
        }

        if(checkShoot)
        {
            Shooting();
        }

        _fireCountDown -= Time.deltaTime;
        if (_fireCountDown < 0)
        {
            ReloadBullet();
            checkShoot = true;
            _fireCountDown = timeBetweenFire;
        }
    }

    private void Shooting()
    {
        checkShoot = false;
        _bullet.gameObject.SetActive(true);
        _bullet.transform.position += (direction * 1.2f + Vector3.down * 0.25f );
        _bullet.Rigit.AddForce(direction * _bullet.Speed, ForceMode2D.Impulse);
    }

    public void Move()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position; // lấy vị trí nhân vật
        if (playerPos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = Vector3.right;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector3.left;
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
