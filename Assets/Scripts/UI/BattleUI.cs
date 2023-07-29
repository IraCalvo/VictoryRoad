using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleUI : MonoBehaviour
{
    private BattleDataHolder battleDataHolder;

    [Header("Opponent UI")]
    public TextMeshProUGUI opponentInformation;
    public Image opponentPokemonHPBar;
    public Image opponentPokemonSprite;

    [Header("Player UI")]
    public TextMeshProUGUI playerPokemonInformation;
    public TextMeshProUGUI playerPokemonHP;
    public Image playerPokemonSprite;

    [Header("Overall Canvas")]
    public List<Image> battleBackground;
    public TextMeshProUGUI batleText;
    public Image OptionBox;
    public Transform fightOptionPosition;
    public Transform bagOptionPosition;
    public Transform pokemonOptionPosition;
    public Transform runOptionPosition;
    public Transform optionArrow;

    private void Awake()
    {
        BattleDataHolder.instance.OnUpdateBattleData += BattleDataHolder_OnUpdateBattleData;
    }

    public void Start()
    {
        BattleDataHolder_OnUpdateBattleData(BattleDataHolder.instance, EventArgs.Empty);
        //BattleDataHolder.instance.OnUpdateBattleData += BattleDataHolder_OnUpdateBattleData;
    }

    private void BattleDataHolder_OnUpdateBattleData(object sender, System.EventArgs e)
    {
        BattleDataHolder Instance = BattleDataHolder.instance;
        GameObject playerPokemon = Instance.playerPokemon;
        GameObject opposingPokemon = Instance.opposingPokemon;

        PokemonBase playerPokemonBase = playerPokemon.GetComponent<PokemonBase>();
        PokemonSO playerPokemonSO = playerPokemonBase.pokemonData;
        playerPokemonSprite.sprite = playerPokemonSO.backSprite;

        PokemonBase opposingPokemonBase = opposingPokemon.GetComponent<PokemonBase>();
        PokemonSO opposingPokemonSO = opposingPokemonBase.pokemonData;
        opponentPokemonSprite.sprite = opposingPokemonSO.opposingSprite;
    }
}
