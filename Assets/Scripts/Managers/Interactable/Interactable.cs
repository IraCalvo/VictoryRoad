using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactAction;
    [SerializeField] Collider2D rangeDetector;

    public void Interact()
    {
        interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            Debug.Log("Playe detected");
            Player player = otherCollider.gameObject.GetComponent<Player>();
            player.isInInteractRange = true;
            player.interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            Player player = otherCollider.gameObject.GetComponent<Player>();
            player.isInInteractRange = false;
            player.interactable = null;
        }
    }
}
