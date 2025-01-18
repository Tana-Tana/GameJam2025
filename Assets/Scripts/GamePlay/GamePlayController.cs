using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public int numberOfKeys = 0;

    private void Start()
    {
        numberOfKeys = 0;
    }

    public void CheckWinCondition()
    {
        if (numberOfKeys == 2)
        {
            Debug.Log("PopUp Win o day");
        }
    }
}
