using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private BoxCollider2D collider_2D;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float groundCheckDistance;
    private PlayerMovement playerMovement;
    private PlayerInfo playerInfo;

    /******************************************************************************/
    private bool isGrounded;
    private void Awake(){
        playerMovement = new PlayerMovement();
        playerInfo = new PlayerInfo();
    }

    void Start()
    {
        groundCheckDistance = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
        playerMovement.Move(playerInfo.GetSpeed(), playerInfo.GetSpeedUp(), rg, isGrounded);
    }

    private void CheckOnGround(){
        Vector3 leftPos = new Vector3(transform.position.x - collider_2D.size.x/2, transform.position.y, transform.position.z);
        Vector3 rightPos = new Vector3(transform.position.x + collider_2D.size.x/2, transform.position.y, transform.position.z);


        bool isGroundedLeft = Physics2D.Raycast(leftPos, Vector2.down, groundCheckDistance, layerMask);
        bool isGroundedRight = Physics2D.Raycast(rightPos, Vector2.down, groundCheckDistance, layerMask);

        isGrounded = isGroundedLeft || isGroundedRight;
        // Debug.Log(isGrounded);
        // Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
        Debug.DrawLine(leftPos, leftPos + Vector3.down * groundCheckDistance, Color.red);
        Debug.DrawLine(rightPos, rightPos + Vector3.down * groundCheckDistance, Color.red);

    }
}
