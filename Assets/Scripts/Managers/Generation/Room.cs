using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public Object roomName;

    private void Start()
    {
        AddRoomToHashSet();
    }

    void AddRoomToHashSet()
    {
        GameManager.instance.visitedRooms.Add(roomName);
    }
}
