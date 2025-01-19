using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Sprite openedGate;
    public Sprite closedGate;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = closedGate;
    }

    public void OpenTheGate()
    {
        spriteRenderer.sprite = openedGate;
        if(GamePlayController.joinGate == 2)
        {
            PanelManager.Instance.OpenPanel(GameConfig.VICTORY_PANEL);
        }
    }
}
