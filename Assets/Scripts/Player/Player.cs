using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int playerTeamSize = 6;
    public List<GameObject> playerPokemonTeam;

    // in run currency, wiped every run
    public int PokeDollar;
    // perma out of run currency
    public int PokeDiamond;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        inventoryManager = GetComponent<InventoryManager>();
    }
}
