using System;

public enum PokemonType
{
       None,
       Normal,
       Fire,
       Water,
       Grass,
       Electric,
       Ice,
       Poison,
       Ground,
       Flying,
       Psychic,
       Bug,
       Rock,
       Ghost,
       Dark,
       Dragon,
       Steel,
       Fairy
}

public enum PokemonNature
{ 
    Hardy,
    Lonely,
    Brave,
    Adamant,
    Naughty,
    Bold,
    Docile,
    Relaxed,
    Impish,
    Lax,
    Timid,
    Hasty,
    Serious,
    Jolly,
    Naive,
    Modest,
    Mild,
    Quiet,
    Bashful,
    Rash,
    Calm,
    Gentle,
    Sassy,
    Careful,
    Quirky
}

public enum PokemonMoveType
{ 
    None,
    Status,
    Attack
}

public enum PokemonAttackType
{ 
    None,
    Physical,
    Special,
    Adaptive
}

public enum PokemonEvolutionMethod
{
    None,
    LevelUp,
    Item,
    Friendship,
    Unique
}

public enum PokemonGender
{ 
    None,
    Male,
    Female
}

public enum PokemonLevelingRate
{ 
    None,
    Fast,
    MediumFast,
    MediumSlow,
    Slow,
    Fluctuating
}

public enum PokemonEggGroup
{ 
    None,
    Monster,
    HumanLike,
    Amorphous,
    Water1,
    Water2,
    Water3,
    Bug,
    Mineral,
    Flying,
    Field,
    Fairy,
    Grass,
    Dragon,
    Ditto
}

public class PokemonEnums
{
    //increases stat by 10% decreases another by 10%
    //public static Tuple<float, string, float, string> CalculateNature(PokemonNature pokemonNature)
    //{
    //    if (pokemonNature == PokemonNature.Hardy)
    //    {
    //        return new Tuple<float, string, float, string>(1.1f, "pokemonAttack", 0.9f, "pokemonDefense");
    //    }
    //}
}
