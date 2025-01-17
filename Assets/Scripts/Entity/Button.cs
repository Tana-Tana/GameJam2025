using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject key; 
    public Sprite buttonUpSprite; 
    public Sprite buttonDownSprite; 
    public float requiredWeight = 1.0f; 

    private float currentWeight = 0.0f; 
    private bool isPressed = false;
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = buttonUpSprite;
        }

        key.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            currentWeight += rb.mass;
            CheckWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
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
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = buttonDownSprite;
        }
        key.SetActive(true);
    }

    private void ReleaseButton()
    {
        isPressed = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = buttonUpSprite;
        }
        key.SetActive(false); 
    }
}
