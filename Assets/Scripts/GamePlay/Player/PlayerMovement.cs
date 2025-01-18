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
        }

        isJump = !isGrounded;
        if(horizontal != 0){
            if(!isJump) isMove = true;
            if(horizontal > 0) isRight = true;
            else isRight = false;
        }
        else isMove = false;
    }

    public void MoveSlide(float speed, float speedUp, Rigidbody2D rg, bool isGrounded, ref bool isMove, ref bool isJump, ref bool isRight){

            rg.velocity = rg.velocity;

        if(Input.GetKeyDown(KeyCode.A)){
            rg.velocity = new Vector2(-speed,0);
            if(!isJump) isMove = true;
            isRight = false;
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            rg.velocity = new Vector2(speed,0);
            if(!isJump) isMove = true;
            isRight = true;
        }
        else{
            isMove = false;
            Debug.Log("tu bi ko tinhf ieu");
        }
       
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, speedUp);
        }
        isJump = !isGrounded;

    }
}
