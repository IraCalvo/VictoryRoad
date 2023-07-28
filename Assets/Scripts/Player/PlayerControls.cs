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
    public GameObject UIMenu;

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
        if (UIMenu.gameObject.activeInHierarchy)
        {
            playerMovement.playerCanMove = true;
            UIMenu.gameObject.SetActive(false);
            MenuOptionManager.Instance.Hide();
        }
        else
        {
            playerMovement.playerCanMove = false;
            Debug.Log(playerMovement.playerCanMove);
            UIMenu.gameObject.SetActive(true);
            MenuOptionManager.Instance.Show();

        }
    }
}
