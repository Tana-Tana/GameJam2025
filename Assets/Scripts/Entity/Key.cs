using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour, ICollectible
{
   public static event Action OnKeyCollected;
   public void Collect()
    {
        Debug.Log("You collected a key");
        Destroy(gameObject);
        OnKeyCollected?.Invoke();
    }
}
