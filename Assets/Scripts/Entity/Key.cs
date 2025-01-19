using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour, ICollectible
{
    public static event Action OnKeyCollected;

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
    }
    public void Collect()
    {
        StartCoroutine(Popping());
    }

    IEnumerator Popping()
    {
        Debug.Log("You collected a key");
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        OnKeyCollected?.Invoke();

        SoundManager.Instance.takeKeySound.Play();
    }

}
