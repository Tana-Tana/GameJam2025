using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal targetPortal;
    private bool isTeleporting = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box") && !isTeleporting)
        {
            Debug.Log("Da cham cong");
            Teleport(other);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") && isTeleporting)
        {
            Debug.Log("Da thoat cong");
            isTeleporting = false;
        }
    }

    private void Teleport(Collider2D player)
    {
        targetPortal.isTeleporting = true;
        isTeleporting = true;
        player.transform.position = targetPortal.transform.position;

    }
}
