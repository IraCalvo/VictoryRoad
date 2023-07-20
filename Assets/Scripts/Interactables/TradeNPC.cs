using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TradeNPC : MonoBehaviour
{
    public PokemonBase pokemonToTrade;
    public PokemonBase pokemonNPCWants;
    Player player;

    [Header("NPC Dialogs")]
    public string NPCInitialDialog;
    public string NPCIfPlayerHasPokemonDialog;
    public string NPCIfPlayerAcceptsTradeDialog;
    public string NPCIfPlayerDeclinesTradeDialog;

    public void InteractedWith()
    {
        //Check if player has pokemon
        player = FindObjectOfType<Player>();

        //dialog to UI system
        Debug.Log(NPCInitialDialog);

        List<PokemonBase> playerPokemonTeamCopy = new List<PokemonBase>(player.playerPokemonTeam);
        foreach (PokemonBase pokemon in player.playerPokemonTeam)
        {
            if(pokemon == pokemonNPCWants)
            {
                Debug.Log(NPCIfPlayerHasPokemonDialog);
                //Ask player if they want to trade as well should be an additional if statement here if they accept or decline

                //if the player accepts the trade
                playerPokemonTeamCopy.Remove(pokemon);
                playerPokemonTeamCopy.Add(pokemonToTrade);
            }
        }
        player.playerPokemonTeam = playerPokemonTeamCopy;
    }
}