using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int playerTeamSize = 6;
    public List<PokemonBase> playerPokemonTeam;
    public Interactable interactable;
    public bool isInInteractRange;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnInteract(InputValue value)
    {
        interactable.Interact();
    }
}
