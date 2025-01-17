using UnityEngine;

public class TrapEnemy : MonoBehaviour, IEnemy
{
    [Header("Element", order = 0)]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigitbody2d;


    [Header("Movement", order = 1)]
    [SerializeField] private float speed = 0;
    [SerializeField] private int direction = 1;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigitbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();    
    }

    public void Move()
    {
        transform.position += Vector3.left * speed * direction * Time.deltaTime;
        Debug.Log("Xét điều kiện đổi hướng nếu cần");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kẻ địch chạm vào người chơi => EndGame");
        }
        else
        {
            Debug.Log("Kẻ địch va chạm vào thứ khác => đổi hướng");
            direction *= -1;
        }
    }
}
