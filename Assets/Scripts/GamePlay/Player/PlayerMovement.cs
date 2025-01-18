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
        }

        isJump = !isGrounded;
        if(horizontal != 0){
            isMove = true;
            if(horizontal > 0) isRight = true;
            else isRight = false;
        }
        else isMove = false;
    }

    // public void Move(float speed, float speedUp, Rigidbody2D rg, bool isGrounded){


    //     if(Input.GetKeyDown(KeyCode.A)){
    //         rg.velocity = new Vector2(-speed,0);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.D)){
    //         rg.velocity = new Vector2(speed,0);
    //     }
    //     else{
    //         Debug.Log("tu bi ko tinhf ieu");
    //     }
       
    //     if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
    //     {
    //         rg.velocity = new Vector2(rg.velocity.x, speedUp);
    //     }
    // }
}
