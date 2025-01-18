using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public static int numberOfKeys = 0;

    private void Start()
    {
        numberOfKeys = 0;
    }

    public void CheckWinCondition()
    {
        if (numberOfKeys == 2)
        {
            PanelManager.Instance.OpenPanel(GameConfig.VICTORY_PANEL);
        }
    }
}
