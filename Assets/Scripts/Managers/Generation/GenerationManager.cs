using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerationManager : MonoBehaviour
{

    public static GenerationManager Instance;
    public Object marketPlace;
    public int roomCounter = 0;
    public int tempBossAmount = 4;

    private HashSet<string> visitedScenes = new HashSet<string>();
    public DirectionType lastEntranceType;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // TODO: REMOVE THE DEFAULT SCENE START
            lastEntranceType = DirectionType.CaveRight;
            LoadRoom(DirectionType.CaveRight);
            DontDestroyOnLoad(this);
        }
    }

    public void LoadRoom(DirectionType entranceType)
    {
        if (tempBossAmount - 2 == roomCounter)
        {
            SceneManager.LoadScene("Market");
        }
        else if (tempBossAmount - 1 == roomCounter)
        {
            SceneManager.LoadScene("TempBoss");
        }
        else
        {
            string sceneName = GetNextRoom(entranceType);
            if (sceneName == null || sceneName == "")
            {
                return;
            }
            lastEntranceType = entranceType;
            SceneManager.LoadScene(sceneName);
        }

        roomCounter++;
    }

    public string GetNextRoom(DirectionType entranceType)
    {

        List<string> roomList = GetListToCheck(entranceType);

        if (visitedScenes.IsSupersetOf(roomList))
        {
            // All rooms have been previously visted
            // TODO: FIGURE OUT WHAT TO DO HERE
        }
        else
        {
            int randomRoomIndex = Random.Range(0, roomList.Count);
            string roomName = roomList[randomRoomIndex];
            while (visitedScenes.Contains(roomName))
            {
                randomRoomIndex = Random.Range(0, roomList.Count);
                roomName = roomList[randomRoomIndex];
            }

            visitedScenes.Add(roomName);
            return roomName;
        }

        return "";
    }

    private List<string> GetListToCheck(DirectionType entranceType)
    {
        if (entranceType == DirectionType.ForestRight)
        {
            return rightForestExits;
        }

        else if (entranceType == DirectionType.CaveRight)
        {
            return rightCaveExits;
        }

        // Default Case
        return new List<string>();
    }

    public bool CheckExitType(DirectionType exitType)
    {
        if (lastEntranceType == exitType)
        {
            return true;
        }
        return false;
    }

    //Player enters a forest towards up
    public static List<string> upForestExits = new List<string>
    {
        "SampleScene",
    };

    //Player enters a forest to the right, ebters new scene from a forest right
    public static List<string> rightForestExits = new List<string>
    {
        "TestGeneration1",
    };

    //Player enters a cave to the right
    public static List<string> rightCaveExits = new List<string>
    {
        "SampleScene",
    };
}

//How I want generation to be handled:
//there's going to be a tracker of how many rooms the player has entered.
//once player enteres a specific amount of rooms theyll enter a "Gym" room. in said gym room after the boss there'll be 4 exits that they can take.
//before (or after not too sure yet) there'll appear a guarenteed "shopping" district where the player can.
//shopping district can appear multiple times in a run, but it should only 'twice' before each gym
//once right before the gym challenge, and potentially appear once before the run
//once they have gone through 8 gym challenges it should begin to generate the super hard rooms leading up to the the e4
//then once the tracker reaches the highest count then the last room brings them to the lobby of the e4
//lobby will be a preset room that will always be the same.

//additional things to generate:
//it can randomly load the "important" NPCs as solo rooms such as the Giovanni NPC room etc.
//helper will track how the player is doing and see if they meet the secret requirements to "potentially" generate "secret" rooms
//said rooms could appear anytime despite the amount of gym challenges done.
//don't know how im going to do other bosses in the generation
//thinking about just having them randomly spawn on a low chance occasinally throughout rooms.
