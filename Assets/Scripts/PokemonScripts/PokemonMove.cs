using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokemonMove", menuName = "Create Pokemon Move")]
public class PokemonMove : ScriptableObject
{
    public string moveName;
    public PokemonMoveType moveType;
    public PokemonAttackType moveAttackType;
    public int moveBasePower;
    public int moveBaseAccuracy;
    public PokemonType movePokemonType;

    [Header("Subcatagories")]
    public bool isSheerForceBoosted;
    public bool isMegaLauncherBoosted;
    public bool isStrongJawBoosted;
    public bool isSharpnessBoosted;
    public bool isIronFistBoosted;
    public bool isPunkRockBoosted;
    public bool isPowderMove;
    public bool isDanceMove;
    public bool isWindMove;
    public bool isBulletProofImmune;
}
