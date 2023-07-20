using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : MonoBehaviour, ISerializationCallbackReceiver
{
    public PokemonSO pokemonData;
    public Animator pokemonWalkingAnimation;
    public int pokemonLevel;
    public PokemonNature pokemonNature;
    private int pokemonMaxLevel = 100;
    private int maxAmountOfEV = 508;
    public int currentAmountOfEV;
    //held item

    [Header("Original Pokemon Stats In Party/Overworld")]
    public float pokemonCurrentCurrentHP;
    public float pokemonCurrentMaxHP;
    public float pokemonAttack;
    public float pokemonDefense;
    public float pokemonSpecialAttack;
    public float pokemonSpecialDefense;
    public float pokemonSpeed;

    [Header("Pokemon IVs and EVs")]
    public float pokemonHPIV;
    public float pokemonAttackIV;
    public float pokemonDefIV;
    public float pokemonSpecialAttackIV;
    public float pokemonSpecialDefenseIV;
    public float pokemonSpeedIV;

    public float pokemonHPEV;
    public float pokemonAttackEV;
    public float pokemonDefEV;
    public float pokemonSpecialAttackEV;
    public float pokemonSpecialDefenseEV;
    public float pokemonSpeedEV;

    [Header("Pokemon Stats In Battle")]
    public float pokemonCurrentBattleAttack;
    public float pokemonCurrentBattleDefense;
    public float pokemonCurrentBattleSpecialAttack;
    public float pokemonCurrentBattleSpecialDefense;
    public float pokemonCurrentBattleSpeed;

    public void OnBeforeSerialize()
    {
        //throw new NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        
    }

    private void Awake()
    {
        GetStats();
        CalculateNormalStats();
    }

    public void GetStats()
    {
        pokemonCurrentMaxHP = pokemonData.baseHP;
    }

    public void CalculateNormalStats()
    {
        //Link to formulas: https://bulbapedia.bulbagarden.net/wiki/Stat
        pokemonCurrentMaxHP = (
            ((2 * pokemonData.baseHP + pokemonHPIV + (pokemonHPEV/4) * pokemonLevel) / 100 )
            + pokemonLevel + 10
            );


    }



    //public void SetStats()
    //{
    //    Tuple<int, string, int, string> stats = PokemonEnums.CalculateNature(pokemonNature);
    //    if (stats.Item2 == "ATK")
    //    {
    //        pokemonAttack += stats.Item1;
    //    }
    //}

}
