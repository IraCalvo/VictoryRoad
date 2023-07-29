using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Create Pokemon")]
public class PokemonSO : ScriptableObject
{
    public string pokemonName;
    //public GameObject pokemonObject;
    public int pokedexNumber;
    public int pokemonLevel;
    public List<PokemonSO> pokemonEvolutions;
    public PokemonEvolutionMethod pokemonEvolutionMethod;

    [Header("Vanilla Stats")]
    //Base Vanilla Stats
    public float baseHP;
    public float baseAttack;
    public float baseDefense;
    public float baseSpecialAttack;
    public float baseSpecialDefense;
    public float baseSpeed;

    //Add Pokemon Type
    public PokemonType type1;
    public PokemonType type2;

    //Add Pokemon Abilities

    //Add Pokemon TOTAL Learnset, Levelup Learnset, TM Learnset, Egg move Learnset
    public List<PokemonMove> totalMoveList;
    public List<PokemonMove> tmMoveList;
    public List<PokemonMove> eggMoveList;
    public List<int> levelUp;
    public List<PokemonMove> levelUpMoves;


    //Adjusted Stats, Types, Abilities, Learnsets
    [Header("Adjusted Stats")]
    //"Adjusted" Stats
    public float baseAdjustedHP;
    public float baseAdjustedAttack;
    public float baseAdjustedDefense;
    public float baseAdjustedSpecialAttack;
    public float baseAdjustedSpecialDefense;
    public float baseAdjustedSpeed;

    //"Adjusted" Type
    public PokemonType adjustedType1;
    public PokemonType adjustedType2;

    //"Adjusted" Ability

    //"Adjusted" Pokemon Learnset
    public List<PokemonMove> adjustedTotalMoveList;
    public List<PokemonMove> adjustedTMMoveList;
    public List<PokemonMove> adjustedEggMoveList;
    public List<int> adjustedLevelUp;
    public List<PokemonMove> adjustedLevelUpMoves;

    [Header("Extra Stats")]
    //Add Misc stats like catch rate, gender rate, weight, Egg type, Cries, etc
    public float catchRate;
    public float genderMaleRate;
    public float genderFemaleRate;
    public float weight;
    public PokemonLevelingRate levelRate;
    public float pokemonSellRate;
    public float pokemonBuyRate;
    public List<PokemonEggGroup> eggGroup;
    public AudioClip pokemonCrySFX;

    [Header("Pokemon Sprites")]
    public Sprite backSprite;
    public Sprite opposingSprite;
    public Sprite shinyBackSprite;
    public Sprite shinyOpposingSprite;
    //public Sprite megaBackSprite;
    //public Sprite megaOpposingSprite;
    //public Sprite
}
