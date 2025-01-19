using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePanel : Panel
{
    private void Start()
    {
        Scene.sceneCurrent = 0;
    }

    public void OpenSetting()
    {
        PanelManager.Instance.OpenPanel(GameConfig.SETTING_PANEL);
    }

    public void OpenLevel1()
    {
        Scene.sceneCurrent = 2;
        SceneManager.LoadScene(Scene.Level1);
    }

    public void OpenLevel2()
    {
        Scene.sceneCurrent = 3;
        SceneManager.LoadScene(Scene.Level2);

    }

    public void OpenLevel3()
    {
        Scene.sceneCurrent = 4;
        SceneManager.LoadScene(Scene.Level3);

    }
}
