using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanel : Panel
{
    public void OpenSetting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }
}
