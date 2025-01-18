using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public void Move(float speed, float speedUp, Rigidbody2D rg, bool isGrounded, ref bool isMove, ref bool isJump, ref bool isRight){
        
        float horizontal = Input.GetAxis("Horizontal"); // Nhận giá trị từ A/D hoặc phím mũi tên
        rg.velocity = new Vector2(horizontal * speed, rg.velocity.y);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, speedUp);
            isMove = false;

            SoundManager.Instance.jumpSound.Play();
        }

        isJump = !isGrounded;
        // if(!isJump) SoundManager.Instance.jumpSound.Stop();

        if(horizontal != 0){
            if(!isJump) isMove = true;
            if(horizontal > 0) isRight = true;
            else isRight = false;

            if (!SoundManager.Instance.walkingSound.isPlaying)
            {
                SoundManager.Instance.walkingSound.Play();
            }
        }
        else {
            isMove = false;

            // SoundManager.Instance.walkingSound.Stop();
            if (SoundManager.Instance.walkingSound.isPlaying)
            {
                SoundManager.Instance.walkingSound.Stop();
            }
        }
    }

    public void MoveSlide(float speed, float speedUp, Rigidbody2D rg, bool isGrounded, ref bool isMove, ref bool isJump, ref bool isRight){

            rg.velocity = rg.velocity;

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            rg.velocity = new Vector2(-speed,0);
            if(!isJump) isMove = true;
            isRight = false;

            SoundManager.Instance.walkingSound.Play();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            rg.velocity = new Vector2(speed,0);
            if(!isJump) isMove = true;
            isRight = true;

            SoundManager.Instance.walkingSound.Play();
        }
        else{
            isMove = false;
            // recode later
            SoundManager.Instance.walkingSound.Stop();
        }
       
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, speedUp);

            SoundManager.Instance.walkingSound.Stop();
        }
        isJump = !isGrounded;
    }
}
