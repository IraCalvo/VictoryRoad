using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public BattleCursor battleCursor;
    private PokemonBase pokemon1; // faster pokemon
    private PokemonBase pokemon2; // slower pokemon

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            battleCursor.OnMoveSelected += BattleCursor_OnMoveSelected;
        }
    }

    private void BattleCursor_OnMoveSelected(object sender, BattleCursor.OnMoveSelectedArgs e)
    {
        //make local (or global) GameObject pokemon1 pokemon 2, store em as player and opponnet, then at the start before calc damage we get speed

        SetTurnOrder();

        PokemonBase playerPokemonBase = BattleDataHolder.instance.GetPlayerPokemonBase();
        PokemonBase opposingPokemonBase = BattleDataHolder.instance.GetOpposingPokemonBase();

        PokemonMove playerPokemonMove = playerPokemonBase.pokemonCurrentMoves[e.index];
        PokemonMove opponentMove = OpponentChooseMove(opposingPokemonBase);

        if (playerPokemonBase == pokemon1)
        {
            Debug.Log(pokemon1.pokemonData.pokemonName + " used " + playerPokemonMove.moveName);
            CalculateDamageToPokemon(pokemon2, playerPokemonMove);

            Debug.Log(pokemon2.pokemonData.pokemonName + " used " + opponentMove.moveName);
            CalculateDamageToPokemon(pokemon1, opponentMove);
        }
        else if (opposingPokemonBase == pokemon1)
        {
            Debug.Log(pokemon1.pokemonData.pokemonName + " used " + opponentMove.moveName);
            CalculateDamageToPokemon(pokemon2, opponentMove);

            Debug.Log(pokemon2.pokemonData.pokemonName + " used " + playerPokemonMove.moveName);
            CalculateDamageToPokemon(pokemon1, playerPokemonMove);
        }

    }

    private void SetTurnOrder()
    {
        PokemonBase playerPokemonBase = BattleDataHolder.instance.GetPlayerPokemonBase();
        PokemonBase opposingPokemonBase = BattleDataHolder.instance.GetOpposingPokemonBase();

        if (playerPokemonBase.pokemonCurrentBattleSpeed > opposingPokemonBase.pokemonCurrentBattleSpeed)
        {
            pokemon1 = playerPokemonBase;
            pokemon2 = opposingPokemonBase;
        }
        else if (playerPokemonBase.pokemonCurrentBattleSpeed < opposingPokemonBase.pokemonCurrentBattleSpeed)
        {
            pokemon1 = opposingPokemonBase;
            pokemon2 = playerPokemonBase;
        }
        else
        {
            int coinflip = Random.Range(0, 100);
            if (coinflip >= 50)
            {
                pokemon1 = playerPokemonBase;
                pokemon2 = opposingPokemonBase;
            }
            else 
            {
                pokemon1 = opposingPokemonBase;
                pokemon2 = playerPokemonBase;
            }
        }
    }

    private PokemonMove OpponentChooseMove(PokemonBase pokemon)
    {
        int index = Random.Range(0, 4);
        PokemonMove move = pokemon.pokemonCurrentMoves[index];
        while (move == null)
        {
            index = Random.Range(0, 4);
            move = pokemon.pokemonCurrentMoves[index];
        }
        return move;
    }

    void CalculateDamageToPokemon(PokemonBase pokemon, PokemonMove move)
    {
        //eventualyl change this to float
        int damage = move.moveBasePower;
        double multipler = CheckEffectiveness(pokemon.pokemonData.type1, move.movePokemonType);
        multipler *= CheckEffectiveness(pokemon.pokemonData.type2, move.movePokemonType);
        damage = (int) (damage * multipler);

        damage = damage + CalculateCriticalHit(damage);

        pokemon.pokemonCurrentCurrentHP -= damage;
        Debug.Log(pokemon.pokemonData.pokemonName + " HP: " + pokemon.pokemonCurrentCurrentHP + "/" + pokemon.pokemonCurrentMaxHP);
    }

    private double CheckEffectiveness(PokemonType pokemonType, PokemonType moveAttackType)
    {
        switch (moveAttackType)
        {
            case PokemonType.None:
                return 1;
            case PokemonType.Normal:
                return 1;
            case PokemonType.Fire:
                return 1;
            case PokemonType.Water:
                return PokemonBattleUtils.CheckEffectivenessWater(pokemonType);
            case PokemonType.Grass:
                return 1;
            case PokemonType.Electric:
                return 1;
            case PokemonType.Ice:
                return 1;
            case PokemonType.Poison:
                return 1;
            case PokemonType.Ground:
                return 1;
            case PokemonType.Flying:
                return 1;
            case PokemonType.Psychic:
                return 1;
            case PokemonType.Bug:
                return 1;
            case PokemonType.Rock:
                return 1;
            case PokemonType.Ghost:
                return 1;
            case PokemonType.Dark:
                return 1;
            case PokemonType.Dragon:
                return 1;
            case PokemonType.Steel:
                return 1;
            case PokemonType.Fairy:
                return 1;
            default:
                return 1;
        }
    }

    public int CalculateCriticalHit(int damage)
    {
        int critDamage = damage / 2;
        int rng = Random.Range(0, 100);
        if (rng < 50)
        {
            Debug.Log("Critical Hit!");
            return critDamage; 
        }
        return 0;
    }
}
