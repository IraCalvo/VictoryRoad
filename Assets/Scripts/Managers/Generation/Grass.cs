using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grass : MonoBehaviour
{
    Collider2D grassCollider;
    public GameObject[] pokemonEncounters;
    public float battleChance;


    private void Awake()
    {
        grassCollider = GetComponent<TilemapCollider2D>();
    }

    public void CheckIfBattle()
    {
        Debug.Log("Called");
        if (Random.value < battleChance)
        {
            StartBattle();
        }
    }

    void StartBattle()
    {
        Debug.Log("Battle Started");
    }
}
