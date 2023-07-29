using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Grass : MonoBehaviour
{
    Collider2D grassCollider;
    public List<GameObject> pokemonEncounters;
    public List<float> encounterRates;
    public float battleChance;


    private void Awake()
    {
        grassCollider = GetComponent<TilemapCollider2D>();
    }

    public void CheckIfBattle()
    {
        if (Random.value < battleChance)
        {
            Debug.Log("Called");
            GameObject pokemon = GetPokemonEncountered();
            StartBattle(pokemon);
        }
    }

    public GameObject GetPokemonEncountered()
    {
        List<GameObject> localPokemonEncounters = new List<GameObject>();
        int index = 0;
        while (index < pokemonEncounters.Count)
        {
            int amountOfPokemon = (int) (encounterRates[index] * 100);
            for (int p = 0; p < amountOfPokemon; p++)
            {
                localPokemonEncounters.Add(pokemonEncounters[index]);
            }
            index++;
        }
        int randomPokemonIndex = Random.Range(0, localPokemonEncounters.Count);

        return localPokemonEncounters[randomPokemonIndex];
    }
    void StartBattle(GameObject pokemonEncountered)
    {
        Debug.Log(pokemonEncountered);
        Debug.Log(pokemonEncountered.GetComponent<PokemonBase>().pokemonData.baseHP);

        SceneManager.LoadScene("BattleScene");
        BattleDataHolder.instance.UpdateBattleData(Player.instance.playerPokemonTeam[0], pokemonEncountered);
    }

    //TODO: Level Fluctuations
}
