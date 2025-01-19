using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject key;
    public GameObject pressedButton;
    public float requiredWeight = 1.0f; 

    private float currentWeight = 0.0f; 
    private bool isPressed = false;
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        Color color = pressedButton.GetComponent<SpriteRenderer>().color;
        color.a = 0f;
        pressedButton.GetComponent<SpriteRenderer>().color = color;
        spriteRenderer = GetComponent<SpriteRenderer>();
        key.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Da nhan!!!!!!!!!!!");
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            currentWeight += rb.mass;
            Debug.Log(currentWeight);
            CheckWeight();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            currentWeight -= rb.mass;
            CheckWeight();
        }
    }

    private void CheckWeight()
    {
        if (currentWeight >= requiredWeight)
        {
            if (!isPressed)
            {
                PressButton();
            }
        }
        else
        {
            if (isPressed)
            {
                ReleaseButton();
            }
        }
    }

    private void PressButton()
    {
        isPressed = true;
        Color color1 = spriteRenderer.color;
        color1.a = 0f;
        spriteRenderer.color = color1;
        Color color2 = pressedButton.GetComponent<SpriteRenderer>().color;
        color2.a = 1f;
        pressedButton.GetComponent<SpriteRenderer>().color = color2;
        key.SetActive(true);
    }

    private void ReleaseButton()
    {
        isPressed = false;
        Color color1 = spriteRenderer.color;
        color1.a = 1f;
        spriteRenderer.color = color1;
        Color color2 = pressedButton.GetComponent<SpriteRenderer>().color;
        color2.a = 0f;
        pressedButton.GetComponent<SpriteRenderer>().color = color2;
        key.SetActive(false); 
    }
}
