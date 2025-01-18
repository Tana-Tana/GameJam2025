using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private CapsuleCollider2D collider_2D;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Camera cam;
    private PlayerMovement playerMovement;
    private PlayerInfo playerInfo;

    /******************************************************************************/
    private bool isGrounded;
    private float padding;
    private bool hasKey;
    /******************************************************************************/
    private bool isMove;
    private bool isJump;
    private bool isDead;
    private bool isWink;
    private bool isRight;
    /******************************************************************************/
    private string moveType;

    private bool checkMove = true;

    private void Awake(){
        playerMovement = new PlayerMovement();
        playerInfo = new PlayerInfo();
    }

    private void Start()
    {
        groundCheckDistance = 0.1f;
        padding = 0.5f;
        hasKey = false;
        ////////////////////////////////////
        isMove = false;
        isJump = false;
        isDead = false;
        isRight = true;
        ////////////////////////////////////
        moveType = GameConfig.GROUND_TAG;

        StartCoroutine(PlayRandomAnimWink());
    }

    private void OnEnable(){
        Messenger.AddListener(EventKey.ENDGAME, SetDead);
        Messenger.AddListener(EventKey.PAUSE, SetNoneSpeed);
        Messenger.AddListener(EventKey.NOT_PAUSE, SetSpeed);
    }
    private void OnDisable(){
        Messenger.RemoveListener(EventKey.ENDGAME, SetDead);
        Messenger.RemoveListener(EventKey.PAUSE, SetNoneSpeed);
        Messenger.RemoveListener(EventKey.NOT_PAUSE, SetSpeed);
    }

    private void Update()
    {
        CheckOnGround();
        if (checkMove)
        {
            if (moveType.Equals(GameConfig.GROUND_TAG)) playerMovement.Move(playerInfo.GetSpeed(), playerInfo.GetSpeedUp(), rg, isGrounded, ref isMove, ref isJump, ref isRight);
            else if (moveType.Equals(GameConfig.BUTTER_TAG)) playerMovement.MoveSlide(playerInfo.GetSpeed(), playerInfo.GetSpeedUp(), rg, isGrounded, ref isMove, ref isJump, ref isRight);
        }
        LimitPosition();

        FlipSprire();
        TransitonAnim();

    }

    private void CheckOnGround(){
        Bounds boundsCollider = collider_2D.bounds;
        Vector2 leftPos = new Vector2(boundsCollider.min.x + 0.2f, boundsCollider.min.y);
        Vector2 rightPos = new Vector2(boundsCollider.max.x - 0.2f, boundsCollider.min.y);

        bool isGroundedLeft = Physics2D.Raycast(leftPos, Vector2.down, groundCheckDistance, layerMask);
        bool isGroundedRight = Physics2D.Raycast(rightPos, Vector2.down, groundCheckDistance, layerMask);
        //Debug.Log(layerMask.value);

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
            GamePlayController.Instance.countKey += 1;
            collectible.Collect();
            hasKey = true;
        }
        if (collision.CompareTag("Gate") && hasKey)
        {
            GamePlayController.joinGate += 1;
            
            collision.GetComponent<Gate>().OpenTheGate();
            transform.DOScale(0f, 1f);
        }

        ////////////////////////////////
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GameConfig.BUTTER_TAG)){moveType = GameConfig.BUTTER_TAG;}
        if(collision.gameObject.CompareTag(GameConfig.GROUND_TAG)){moveType = GameConfig.GROUND_TAG;}
    }

    private void TransitonAnim(){
        animator.SetBool("isMove", isMove);
        animator.SetBool("isJump", isJump);
        animator.SetBool("isWink", isWink);
        animator.SetBool("isDead", isDead);
    }

    private void SetDead(){
        isDead = true;
        
        checkMove = false;
        PanelManager.Instance.OpenPanel(GameConfig.DEFEAT_PANEL);


        SoundManager.Instance.dieSound.Play();
        SoundManager.Instance.loseSound.Play();
    }

    private IEnumerator PlayRandomAnimWink()
    {
        while (true)
        {
            // Tạo khoảng thời gian ngẫu nhiên
            float waitTime = Random.Range(3f, 6f);

            // Chờ đợi khoảng thời gian ngẫu nhiên
            yield return new WaitForSeconds(waitTime);

            // Kích hoạt animation
            isWink = true;
            yield return new WaitForSeconds(0.2f);
            isWink = false;

        }
    }

    private void FlipSprire(){
        if(!isRight){
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }

    private void SetSpeed()
    {
        checkMove = true;
    }

    private void SetNoneSpeed()
    {
        checkMove = false;
    }
}
