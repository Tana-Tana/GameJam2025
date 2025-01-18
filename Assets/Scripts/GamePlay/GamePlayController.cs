using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public static int joinGate = 0;
    public int countKey = 0;

    private void Start()
    {
        joinGate = 0;
        countKey = 0;
    }
}
