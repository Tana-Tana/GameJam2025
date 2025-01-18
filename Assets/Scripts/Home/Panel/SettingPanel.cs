using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : Panel
{
    [Header("Element", order = 0)]
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject overlayUI;

    [Header("MUSIC", order = 1)]
    [SerializeField] private GameObject tickOfMusic;
    [SerializeField] private int stateMusic;

    [Header("SOUND", order = 2)]
    [SerializeField] private GameObject tickOfSound;
    [SerializeField] private int stateSound;


    private void Start()
    {
        popup.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
        LoadMusicAndSound();
    }

    private void LoadMusicAndSound()
    {
        stateMusic = GamePrefs.GetMusic();
        stateSound = GamePrefs.GetSound();
        if (stateMusic == 0) tickOfMusic.SetActive(false);
        else tickOfMusic.SetActive(true);
        if (stateSound == 0) tickOfSound.SetActive(false);
        else tickOfSound.SetActive(true);
    }

    public async void ExitSetting()
    {
        GamePrefs.SetMusic(stateMusic);
        GamePrefs.SetSound(stateSound);
        // popup
        popup.transform.DOScale(0, 0.5f).SetEase(Ease.OutQuint);
        overlayUI.transform.DOScale(0, 0.5f).SetEase(Ease.OutQuint);
        await Task.Delay(500);
        PanelManager.Instance.ClosePanel(GameConfig.SETTING_PANEL);
    }

    public void tickMusic()
    {
        if (tickOfMusic.activeSelf)
        {
            stateMusic = 0;
            tickOfMusic.SetActive(false);
        }
        else
        {
            stateMusic = 1;
            tickOfMusic.SetActive(true);
        }
    }

    public void tickSound()
    {
        if (tickOfSound.activeSelf)
        {
            stateSound = 0;
            tickOfSound.SetActive(false);
        }
        else
        {
            stateSound = 1;
            tickOfSound.SetActive(true);
        }
    }

}
