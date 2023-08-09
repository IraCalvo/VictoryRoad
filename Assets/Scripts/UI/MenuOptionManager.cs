using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuOptionManager : MonoBehaviour
{
    public static MenuOptionManager Instance { get; private set; }

    public GameObject UIOptionPrefab;
    public GameObject cursorPrefab;
    private GameObject initializedCursor;
    Vector2 cursorInput;
    private int cursorIndex = 0;
    public GameObject UIMenu;


    public List<string> menuNames = new List<string>();

    private float yOffset = -130f;

    private void Awake()
    {
        Instance = this;

        menuNames.Add("Pokedex");
        menuNames.Add("Pokemon");
        menuNames.Add("Bag");
        menuNames.Add("PokeNav");
        menuNames.Add("ID");
        menuNames.Add("Save");
        menuNames.Add("Options");
        menuNames.Add("Exit");

        CreateMenu();
        Hide();
    }
    public void CreateMenu()
    {

        float cursorXOffset = -35f;
        float cursorYOffset = -10f;
        int index = 0;
        foreach (string menuOption in menuNames)
        {
            GameObject menuOptionPrefab = Instantiate(UIOptionPrefab, transform);
            menuOptionPrefab.GetComponent<TextMeshProUGUI>().text = menuOption;
            menuOptionPrefab.transform.position = new Vector2(transform.position.x, transform.position.y + (index * yOffset));
            index++;
        }

        GameObject firstObject = transform.GetChild(0).gameObject;
        initializedCursor = Instantiate(cursorPrefab, firstObject.transform.position, Quaternion.identity, transform);
        initializedCursor.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        initializedCursor.transform.position = new Vector2(transform.position.x + cursorXOffset, transform.position.y + cursorYOffset);
    }

    public void ResetUIWithList(List<string> list)
    {
        MenuOptionManager.Instance.menuNames = list;
        // Remove all existing children
        CreateMenu();
    }


    void OnMove(InputValue value)
    {
        cursorInput = value.Get<Vector2>();
        int direction = (int)Mathf.Round(cursorInput.y);
        if (direction == -1)
        {
            // Move Down
            // Check if there is a down option
            if (cursorIndex < menuNames.Count - 1)
            {
                initializedCursor.transform.position += new Vector3(0, yOffset, 0);
                cursorIndex++;
            }
            
        }
        else if (direction == 1)
        {
            // Move Up
            // Check if there is a up option
            if (cursorIndex > 0)
            {
                initializedCursor.transform.position += new Vector3(0, -yOffset, 0);
                cursorIndex--;
            }
            
        }
    }

    public void Show()
    {
        UIMenu.SetActive(true);
    }

    public void Hide()
    {
        UIMenu.SetActive(false);
    }
}
