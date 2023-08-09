using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Interactable interactable;
    public bool isInInteractRange;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnInteract(InputValue value)
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    void OnStart(InputValue value)
    {
        if (MenuOptionManager.Instance.UIMenu.gameObject.activeInHierarchy)
        {
            playerMovement.playerCanMove = true;
            MenuOptionManager.Instance.UIMenu.gameObject.SetActive(false);
            MenuOptionManager.Instance.Hide();
        }
        else
        {
            playerMovement.playerCanMove = false;
            Debug.Log(playerMovement.playerCanMove);
            MenuOptionManager.Instance.UIMenu.gameObject.SetActive(true);
            MenuOptionManager.Instance.Show();

        }
    }
}
