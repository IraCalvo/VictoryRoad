using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowerPokemon : MonoBehaviour
{
    public PlayerMovement playerInput;
    public float pokemonWalkingMS;
    public GameObject spotNorth;
    public GameObject spotSouth;
    public GameObject spotWest;
    public GameObject spotEast;
    public GameObject spotNorthEast;
    public GameObject spotNorthWest;
    public GameObject spotSouthEast;
    public GameObject spotSouthWest;

    public Animator pokemonWalkingAnimation;
    public Animator followerAnimator;
    public Player playerParty;

    private Vector2 lastPlayerInput;

    private void Start()
    {
        GetPokemonFirstInParty();
    }

    void Update()
    {
        PokemonFollowSpot();
        PokemonWalkingAnimation();
    }
    public void GetPokemonFirstInParty()
    {
        if(playerParty.playerPokemonTeam.Count > 0)
        {
            pokemonWalkingAnimation = playerParty.playerPokemonTeam[0].pokemonWalkingAnimation;
            followerAnimator.runtimeAnimatorController = pokemonWalkingAnimation.runtimeAnimatorController;
            
        }
    }
    void PokemonFollowSpot()
    {
        float playerMoveX = Mathf.Round(playerInput.moveInput.x);
        float playerMoveY = Mathf.Round(playerInput.moveInput.y);

        // Player going to last input
        if (playerMoveX == 0 && playerMoveY == 0)
        {
            playerMoveX = lastPlayerInput.x;
            playerMoveY = lastPlayerInput.y;
        }

        // Player going North Pokemon South
        if (playerMoveX == 0 && playerMoveY == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotSouth.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going South Pokemon North
        if (playerMoveX == 0 && playerMoveY == -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotNorth.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going East Pokemon West
        if (playerMoveX == 1 && playerMoveY == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotWest.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going West Pokemon going East
        if (playerMoveX == -1 && playerMoveY == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotEast.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going NorthEast Pokemon going SouthWest
        if (playerMoveX == 1 && playerMoveY == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotSouthWest.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going NorthWest Pokemon going SouthEast
        if (playerMoveX == -1 && playerMoveY == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotSouthEast.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going SouthEast Pokemon going NorthWest
        if (playerMoveX == 1 && playerMoveY == -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotNorthWest.transform.position, pokemonWalkingMS * Time.deltaTime);
        }
        // Player going SouthWest Pokemon going NorthEast
        if (playerMoveX == -1 && playerMoveY == -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, spotNorthEast.transform.position, pokemonWalkingMS * Time.deltaTime);
        }

        lastPlayerInput = new Vector2(Mathf.Round(playerInput.moveInput.x), Mathf.Round(playerInput.moveInput.y));
    }

    public void PokemonWalkingAnimation()
    {
        //if player is going North, NorthWest, or NorthEast
        if (lastPlayerInput.x == 0 && lastPlayerInput.y == 1)
        {
            followerAnimator.SetBool("isWalkingUp", true);
            followerAnimator.SetBool("isWalkingDown", false);
            followerAnimator.SetBool("isWalkingRight", false);
            followerAnimator.SetBool("isWalkingLeft", false);
        }

        //if player is going South, SouthWest, SouthEast
        if (lastPlayerInput.x == 0 && lastPlayerInput.y == -1)
        {
            followerAnimator.SetBool("isWalkingUp", false);
            followerAnimator.SetBool("isWalkingDown", true);
            followerAnimator.SetBool("isWalkingRight", false);
            followerAnimator.SetBool("isWalkingLeft", false);

        }

        //if player is going East
        if (lastPlayerInput.x == 1 && lastPlayerInput.y == 0)
        {
            followerAnimator.SetBool("isWalkingUp", false);
            followerAnimator.SetBool("isWalkingDown", false);
            followerAnimator.SetBool("isWalkingRight", true);
            followerAnimator.SetBool("isWalkingLeft", false);
        }

        //if player is going West
        if (lastPlayerInput.x == -1 && lastPlayerInput.y == 0)
        {
            followerAnimator.SetBool("isWalkingUp", false);
            followerAnimator.SetBool("isWalkingDown", false);
            followerAnimator.SetBool("isWalkingRight", false);
            followerAnimator.SetBool("isWalkingLeft", true);
        }
    }
}
