using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentAmountOfRoomsExplored;
    public HashSet<Object> visitedRooms = new HashSet<Object>();
    public bool vanillaPokemon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ClearVisitedRooms();
    }

    public void MarkVisitedRoom(Object room)
    {
        visitedRooms.Add(room);
    }

    //TODO: add a way to remove everything from the list upon a starting a new run
    public void ClearVisitedRooms()
    {
        visitedRooms.Clear();
    }
}
