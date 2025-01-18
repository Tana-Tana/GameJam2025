using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public static int joinGate = 0;
    public int countKey = 0;

    private void Start()
    {
        numberOfKeys = 0;
    }

	private void Update() {
		CheckWinCondition();
	}    
	public void CheckWinCondition()
    {
        if (numberOfKeys == 2)
        {
         	PanelManager.Instance.OpenPanel(GameConfig.VICTORY_PANEL);
            SoundManager.Instance.winSound.Play();
        }
    }

    private void Update(){
        if (Input.GetMouseButtonDown(0)) 
        {
            SoundManager.Instance.clickSound.Play();
        }
    }
}
