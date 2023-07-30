using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BattleCursor : MonoBehaviour
{
    public GameObject optionCursor;
    public GameObject battleCursor;
    private Vector2 cursorInput;

    private int cursorIndexX;
    private int cursorIndexY;

    public event EventHandler<OnMoveSelectedArgs> OnMoveSelected;

    public class OnMoveSelectedArgs : EventArgs 
    {
        public int index;
    }

    void OnMove(InputValue value)
    {
        cursorInput = value.Get<Vector2>();

        if (cursorInput.y == -1 && cursorIndexY < 1)
        {
            cursorIndexY++;
        }
        if (cursorInput.y == 1 && cursorIndexY == 1)
        {
            cursorIndexY--;
        }
        if (cursorInput.x == 1 && cursorIndexX < 1)
        {
            cursorIndexX++;
        }
        if (cursorInput.x == -1 && cursorIndexX == 1)
        {
            cursorIndexX--;
        }

        updateOptionCursorPosition();
    }

    void updateOptionCursorPosition()
    {
        //option selector
        if (BattleUI.instance.optionBox.gameObject.activeInHierarchy)
        {
            if (cursorIndexX == 0 && cursorIndexY == 0)
            {
                optionCursor.transform.position = BattleUI.instance.fightOptionPosition.transform.position;
            }
            if (cursorIndexX == 1 && cursorIndexY == 0)
            {
                optionCursor.transform.position = BattleUI.instance.bagOptionPosition.transform.position;
            }
            if (cursorIndexX == 0 && cursorIndexY == 1)
            {
                optionCursor.transform.position = BattleUI.instance.pokemonOptionPosition.transform.position;
            }
            if (cursorIndexX == 1 && cursorIndexY == 1)
            {
                optionCursor.transform.position = BattleUI.instance.runOptionPosition.transform.position;
            }
        }

        //move selector
        if (BattleUI.instance.moveOptionBox.gameObject.activeInHierarchy)
        {
            if (cursorIndexX == 0 && cursorIndexY == 0)
            {
                battleCursor.transform.position = BattleUI.instance.move1Position.transform.position;
            }
            if (cursorIndexX == 1 && cursorIndexY == 0)
            {
                battleCursor.transform.position = BattleUI.instance.move2Position.transform.position;
            }
            if (cursorIndexX == 0 && cursorIndexY == 1)
            {
                battleCursor.transform.position = BattleUI.instance.move3Position.transform.position;
            }
            if (cursorIndexX == 1 && cursorIndexY == 1)
            {
                battleCursor.transform.position = BattleUI.instance.move4Position.transform.position;
            }
        }
    }

    void OnInteract(InputValue value)
    {
        if (optionCursor.transform.position == BattleUI.instance.fightOptionPosition.transform.position && optionCursor.activeInHierarchy)
        {
            BattleUI.instance.optionBox.gameObject.SetActive(false);
            optionCursor.SetActive(false);

            BattleUI.instance.moveOptionBox.gameObject.SetActive(true);
            battleCursor.SetActive(true);
        }

        else if (optionCursor.transform.position == BattleUI.instance.runOptionPosition.transform.position && optionCursor.activeInHierarchy)
        {
            PlayerMovement.instance.playerCanMove = true;
            SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
        }

        else if (battleCursor.activeInHierarchy)
        {
            int moveIndex = GetMoveIndex();

            OnMoveSelectedArgs args = new OnMoveSelectedArgs();
            args.index = moveIndex;
            OnMoveSelected?.Invoke(this, args);
        }
    }

    void OnBack(InputValue value)
    {
        //leaving moves back to the 4 options
        if (BattleUI.instance.moveOptionBox.gameObject.activeInHierarchy)
        {
            BattleUI.instance.moveOptionBox.gameObject.SetActive(false);
            battleCursor.SetActive(false);

            BattleUI.instance.optionBox.gameObject.SetActive(true);
            optionCursor.SetActive(true);
        }
    }

    private int GetMoveIndex()
    {
        if (battleCursor.transform.position == BattleUI.instance.move1Position.transform.position)
        {
            return 0;
        }
        if (battleCursor.transform.position == BattleUI.instance.move2Position.transform.position)
        {
            return 1;
        }
        if (battleCursor.transform.position == BattleUI.instance.move3Position.transform.position)
        {
            return 2;
        }
        if (battleCursor.transform.position == BattleUI.instance.move4Position.transform.position)
        {
            return 3;
        }
        return 0;
    }
}
