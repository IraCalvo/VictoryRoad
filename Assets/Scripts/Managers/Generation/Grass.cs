using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Grass : MonoBehaviour
{
    Collider2D grassCollider;
    public List<GameObject> pokemonEncounters;
    public List<float> encounterRates;
    public List<int> pokemonLevels;
    public List<float> levelRates;
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
            int level = DeterminePokemonLevel();
            StartBattle(pokemon, level);
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
        GameObject pokemonEncounter = Instantiate(localPokemonEncounters[randomPokemonIndex]);
        DontDestroyOnLoad(pokemonEncounter);
        return pokemonEncounter;
    }

    public int DeterminePokemonLevel()
    {
        List<int> localLevelRates = new List<int>();
        int index = 0;
        while (index < pokemonLevels.Count)
        {
            int possibleLevel = (int)(levelRates[index] * 100);
            for (int l = 0; l < possibleLevel; l++ )
            {
                localLevelRates.Add(pokemonLevels[index]);
            }
            index++;
        }
        int randomPokemonLevel = Random.Range(0, localLevelRates.Count);

        return (localLevelRates[randomPokemonLevel]);
    }

    void StartBattle(GameObject pokemonEncountered, int pokemonSpawnLevel)
    {
        Debug.Log(pokemonEncountered);
        Debug.Log(pokemonEncountered.GetComponent<PokemonBase>().pokemonData.baseHP);
        pokemonEncountered.GetComponent<PokemonBase>().pokemonLevel = pokemonSpawnLevel;
        Debug.Log(pokemonEncountered + "Spawned at Level:" + pokemonSpawnLevel);

        // TODO: SET TO LAST CURRENT SCENE
        PlayerPrefs.SetString("CurrentScene", "SampleScene");

        SceneManager.LoadScene("BattleScene");
        BattleDataHolder.instance.UpdateBattleData(Player.instance.playerPokemonTeam[0], pokemonEncountered);
        PlayerMovement.instance.playerCanMove = false;
    }

    //TODO: Level Fluctuations
}
