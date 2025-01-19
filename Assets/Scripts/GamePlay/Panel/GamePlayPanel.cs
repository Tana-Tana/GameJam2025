using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayPanel : Panel
{
    [SerializeField] private TextMeshProUGUI keyCount;

    private void Start()
    {
        keyCount.text = GamePlayController.Instance.countKey.ToString();    
    }

    private void Update()
    {
        keyCount.text = GamePlayController.Instance.countKey.ToString();
    }

    public void OpenPauseGame()
    {
        Messenger.Broadcast(EventKey.PAUSE);
        PanelManager.Instance.OpenPanel(GameConfig.PAUSE_PANEL);
    }
}
