using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : Panel
{
    [SerializeField] private float timeLoading = 0.1f;
    [SerializeField] private Image loading;

    private async void Update()
    {
        loading.fillAmount -= Time.deltaTime * timeLoading;
        if (loading.fillAmount <= 0)
        {
            await Task.Delay(1000);
            PanelManager.Instance.OpenPanel(GameConfig.HOME_PANEL);
            PanelManager.Instance.ClosePanel(GameConfig.LOADING_PANEL);
        }
    }
}
