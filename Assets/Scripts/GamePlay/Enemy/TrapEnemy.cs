using UnityEngine;

public class TrapEnemy : MonoBehaviour, IEnemy
{
    [Header("Element", order = 0)]
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private Rigidbody2D rigitbody2d;
    [SerializeField] private BoxCollider2D leftCol;
    [SerializeField] private BoxCollider2D rightCol;


    [Header("Movement", order = 1)]
    [SerializeField] private float speed = 3;
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private float moveTime = 5;

    // private
    private float moveCountdown = 5;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        rigitbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveCountdown -= Time.deltaTime;
        if (moveCountdown < 0)
        {
            moveCountdown = moveTime;
            direction *= -1;
            Vector3 currentDirection = transform.eulerAngles;
            currentDirection.y += 180;
            transform.eulerAngles = currentDirection;
        }
        Move();
    }

    public void Move()
    {
        if (leftCol != null && leftCol.IsTouchingLayers(LayerMask.GetMask("Ground")) || rightCol != null && rightCol.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            direction *= -1;
            Vector3 currentDirection = transform.eulerAngles;
            currentDirection.y += 180;
            transform.eulerAngles = currentDirection;
            moveCountdown = moveTime;
        }
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Messenger.Broadcast(EventKey.ENDGAME);
            Debug.Log("Kẻ địch chạm vào người chơi => EndGame");
        }
    }

}
