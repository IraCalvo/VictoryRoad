using System.Collections;
using UnityEngine;


public class PokemonBattleUtils
{
    //static bool SuperEffectivenessFire(PokemonType pokemonType)
    //{
    //    switch (pokemonType)
    //    {
    //        case PokemonType.None:
    //            break;
    //        case PokemonType.Normal:
    //            break;
    //        case PokemonType.Fire:
    //            break;
    //        case PokemonType.Water:
    //            break;
    //        case PokemonType.Grass:
    //            break;
    //        case PokemonType.Electric:
    //            break;
    //        case PokemonType.Ice:
    //            break;
    //        case PokemonType.Poison:
    //            break;
    //        case PokemonType.Ground:
    //            break;
    //        case PokemonType.Flying:
    //            break;
    //        case PokemonType.Psychic:
    //            break;
    //        case PokemonType.Bug:
    //            break;
    //        case PokemonType.Rock:
    //            break;
    //        case PokemonType.Ghost:
    //            break;
    //        case PokemonType.Dark:
    //            break;
    //        case PokemonType.Dragon:
    //            break;
    //        case PokemonType.Steel:
    //            break;
    //        case PokemonType.Fairy:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    static public double CheckEffectivenessWater(PokemonType pokemonType)
    {
        switch (pokemonType)
        {
            case PokemonType.None:
                return 1;
            case PokemonType.Normal:
                return 1;
            case PokemonType.Fire:
                return 2;
            case PokemonType.Water:
                return 0.5;
            case PokemonType.Grass:
                return 0.5;
                //change after testing
            case PokemonType.Electric:
                return 2;
            case PokemonType.Ice:
                return 1;
            case PokemonType.Poison:
                return 1;
            case PokemonType.Ground:
                return 2;
            case PokemonType.Flying:
                return 1;
            case PokemonType.Psychic:
                return 1;
            case PokemonType.Bug:
                return 1;
            case PokemonType.Rock:
                return 2;
            case PokemonType.Ghost:
                return 1;
            case PokemonType.Dark:
                return 1;
            case PokemonType.Dragon:
                return 0.5;
            case PokemonType.Steel:
                return 1;
            case PokemonType.Fairy:
                return 1;
            default:
                return 1;
        }
    }

}