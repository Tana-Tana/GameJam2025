using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class VictoryPanel : Panel
{
    [Header("Element", order = 0)]
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject overlayUI;

    private void Start()
    {
        popup.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }

    public async void NextLevel()
    {
        // popup
        popup.transform.DOScale(0, 0.5f).SetEase(Ease.OutQuint);
        overlayUI.transform.DOScale(0, 0.5f).SetEase(Ease.OutQuint);
        await Task.Delay(500);
        PanelManager.Instance.ClosePanel(GameConfig.PAUSE_PANEL);
    }
}
