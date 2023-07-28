using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int playerTeamSize = 6;
    public List<PokemonBase> playerPokemonTeam;

    // in run currency, wiped every run
    public int PokeDollar;
    // perma out of run currency
    public int PokeDiamond;
    public InventoryManager inventoryManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        inventoryManager = GetComponent<InventoryManager>();
    }
}
