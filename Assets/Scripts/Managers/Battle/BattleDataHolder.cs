using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleDataHolder : MonoBehaviour
{
    public static BattleDataHolder instance;
    public event EventHandler OnUpdateBattleData;

    public GameObject playerPokemon;
    public GameObject opposingPokemon;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateBattleData(GameObject playerPokemon, GameObject opposingPokemon)
    {
        instance.playerPokemon = playerPokemon;
        instance.opposingPokemon = opposingPokemon;
        OnUpdateBattleData?.Invoke(this, EventArgs.Empty);
    }
}
