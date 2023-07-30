using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleUI : MonoBehaviour
{
    private BattleDataHolder battleDataHolder;
    public static BattleUI instance;

    [Header("Opponent UI")]
    public TextMeshProUGUI opponentInformation;
    public Image opponentPokemonHPBar;
    public Image opponentPokemonSprite;

    [Header("Player UI")]
    public TextMeshProUGUI playerPokemonInformation;
    public TextMeshProUGUI playerPokemonHP;
    public Image playerPokemonSprite;

    [Header("Player Pokemon Moves")]
    public Image moveOptionBox;
    public Transform move1Position;
    public Transform move2Position;
    public Transform move3Position;
    public Transform move4Position;
    public List<TextMeshProUGUI> moves;

    [Header("Overall Canvas")]
    public List<Image> battleBackground;
    public TextMeshProUGUI batleText;
    public Image optionBox;
    public Transform fightOptionPosition;
    public Transform bagOptionPosition;
    public Transform pokemonOptionPosition;
    public Transform runOptionPosition;
    public Transform optionArrow;


    private void Awake()
    {
        BattleDataHolder.instance.OnUpdateBattleData += BattleDataHolder_OnUpdateBattleData;
        if (instance == null)
        {
            instance = this;
        }
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

        for (int m = 0; m < playerPokemonBase.pokemonCurrentMoves.Count; m++)
        {
            if (playerPokemonBase.pokemonCurrentMoves[m] == null)
            {
                moves[m].text = " - ";
            }
            else 
            {
                moves[m].text = playerPokemonBase.pokemonCurrentMoves[m].moveName;
            }
        }

    }
}
