using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public void Move(float speed, float speedUp, Rigidbody2D rg, bool isGrounded){
        
        float horizontal = Input.GetAxis("Horizontal"); // Nhận giá trị từ A/D hoặc phím mũi tên
        rg.velocity = new Vector2(horizontal * speed, rg.velocity.y);
       
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, speedUp);
        }
    }
}
