using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private BoxCollider2D collider_2D;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Camera cam;
    private PlayerMovement playerMovement;
    private PlayerInfo playerInfo;

    /******************************************************************************/
    private bool isGrounded;
    private float padding;
    private void Awake(){
        playerMovement = new PlayerMovement();
        playerInfo = new PlayerInfo();
    }

    private void Start()
    {
        groundCheckDistance = 0.1f;
        padding = 0.5f;
    }

    private void Update()
    {
        CheckOnGround();
        playerMovement.Move(playerInfo.GetSpeed(), playerInfo.GetSpeedUp(), rg, isGrounded);

        LimitPosition();
    }

    private void CheckOnGround(){
        Bounds boundsCollider = collider_2D.bounds;
        Vector2 leftPos = new Vector2(boundsCollider.min.x, boundsCollider.min.y);
        Vector2 rightPos = new Vector2(boundsCollider.max.x, boundsCollider.min.y);

        bool isGroundedLeft = Physics2D.Raycast(leftPos, Vector2.down, groundCheckDistance, layerMask);
        bool isGroundedRight = Physics2D.Raycast(rightPos, Vector2.down, groundCheckDistance, layerMask);

        isGrounded = isGroundedLeft || isGroundedRight;
        
        // Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
        Debug.DrawLine(leftPos, leftPos + Vector2.down * groundCheckDistance, Color.red);
        Debug.DrawLine(rightPos, rightPos + Vector2.down * groundCheckDistance, Color.red);

    }

    private void LimitPosition(){
        Vector2 screenBounds;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        Vector3 camPos = cam.gameObject.transform.position;

        // Giới hạn vị trí player
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, camPos.x - (screenBounds.x - camPos.x) + padding, screenBounds.x - padding);
        // position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + padding, screenBounds.y - padding);
        transform.position = position;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
    }
}
