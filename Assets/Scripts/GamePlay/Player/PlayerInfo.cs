using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private float speed = 6f;
    private float speedUp = 10f;

    public float GetSpeed(){
        return speed;   
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetSpeedUp(){
        return speedUp;
    }

}
