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
    }

	private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.clickSound.Play();
        }
        CheckWinCondition();
	}    
	public void CheckWinCondition()
    {
        if (joinGate == 2)
        {
            SoundManager.Instance.winSound.Play();
        }
    }

}
