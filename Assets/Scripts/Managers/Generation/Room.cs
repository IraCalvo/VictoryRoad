using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public Object roomName;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        List<RoomDoor> roomDoors = new List<RoomDoor>();
        roomDoors = FindObjectsOfType<RoomDoor>().ToList();

        List<RoomDoor> validRoomExits = new List<RoomDoor>();
        foreach(RoomDoor roomDoor in roomDoors)
        {
            if (SceneManagerData.Instance.CheckExitType(roomDoor.Exit))
            {
                validRoomExits.Add(roomDoor);
            }
        }
        int randomIndex = Random.Range(0, validRoomExits.Count);
        RoomDoor playerRoomExit = validRoomExits[randomIndex];
        playerRoomExit.gameObject.SetActive(false);
        player.transform.position = playerRoomExit.spawnPosition.position;

    }
    private void Start()
    {
        AddRoomToHashSet();
    }

    void AddRoomToHashSet()
    {
        GameManager.instance.visitedRooms.Add(roomName);
    }
}
