using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;

public class Pokedex : MonoBehaviour
{
    //public List<Pokemon> pokemonList = new List<Pokemon>();
    private PokemonSO[] pokemonObjects;
    Dictionary<string, PokemonSO> pokedex = new Dictionary<string, PokemonSO>();
    private PokemonMove[] pokemonMoveObjects;
    Dictionary<string, PokemonMove> pokemonMoveDex = new Dictionary<string, PokemonMove>();

    public void Start()
    {
        LoadPokedex();
        LoadPokemonMoves();
    }

    void LoadPokedex()
    {
        pokemonObjects = Resources.LoadAll("ScriptableObjects/Pokemon", typeof(PokemonSO)).Cast<PokemonSO>().ToArray();
        foreach (PokemonSO pokemon in pokemonObjects)
        {
            pokedex.Add(pokemon.pokemonName, pokemon);
        }

        PokemonSO findingPokemon = pokedex["Squirtle"];
        Debug.Log(findingPokemon);
    }

    void LoadPokemonMoves()
    {
        pokemonMoveObjects = Resources.LoadAll("ScriptableObjects/Moves", typeof(PokemonMove)).Cast<PokemonMove>().ToArray();
        foreach(PokemonMove move in pokemonMoveObjects)
        {
            pokemonMoveDex.Add(move.moveName, move);
        }

        PokemonMove findMove = pokemonMoveDex["Growl"];
        Debug.Log(findMove);
        Debug.Log(findMove.movePokemonType);
    }
}
