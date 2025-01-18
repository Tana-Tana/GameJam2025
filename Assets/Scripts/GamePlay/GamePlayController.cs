using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public static int numberOfKeys;

    private void Start()
    {
        numberOfKeys = 0;
    }

    public void CheckWinCondition()
    {
        if (numberOfKeys == 2)
        {
            Debug.Log("Bat anim chet");
            Debug.Log("PopUp Win o day");
            Debug.Log("Lam observer");
        }
    }
}
