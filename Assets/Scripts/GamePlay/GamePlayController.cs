using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public static int joinGate = 0;
    private bool isPlayerDead;
    public int countKey = 0;
    private bool isWined;

    private void Start()
    {
        joinGate = 0;
        isPlayerDead = false;
        isWined = false;
    }

    private void OnEnable(){
        Messenger.AddListener(EventKey.ENDGAME, SetPlayerDead);
    }
    private void OnDisable(){
        Messenger.RemoveListener(EventKey.ENDGAME, SetPlayerDead);
    }

	private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.clickSound.Play();
        }
        if(!isWined){
            CheckWinCondition();
        }
	}    
	public void CheckWinCondition()
    {
        if (joinGate == 2 && !isPlayerDead)
        {
            isWined = true;
            SoundManager.Instance.winSound.Play();
            PanelManager.Instance.OpenPanel(GameConfig.VICTORY_PANEL);
        }
    }

    private void SetPlayerDead(){
        isPlayerDead = true;
    }

}
