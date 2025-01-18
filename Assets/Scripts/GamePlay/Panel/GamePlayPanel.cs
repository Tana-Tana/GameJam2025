using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayPanel : Panel
{
    [SerializeField] private TextMeshProUGUI keyCount;

    private void Start()
    {
        keyCount.text = GamePlayController.Instance.numberOfKeys.ToString();    
    }

    private void Update()
    {
        keyCount.text = GamePlayController.Instance.numberOfKeys.ToString();
    }

    public void OpenPauseGame()
    {
        Time.timeScale = 0;
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
    }
}
