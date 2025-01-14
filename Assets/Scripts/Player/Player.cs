using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
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
        Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
    }

    private void CheckOnGround(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, layerMask);
        isGrounded = hit.collider != null;
        Debug.Log(isGrounded);
    }
}
