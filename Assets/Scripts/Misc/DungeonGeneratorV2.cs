using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneratorV2 : MonoBehaviour
{
    public List<Dungeon> dungeonTypes;
    public int numberOfRooms = 10;

    private List<GameObject> exitsInCurrentRoom;
    private Dungeon currentDungeonType;
    private GameObject chosenPiece;
    private GameObject currentRoom;
    private GameObject chosenExit;
    
    private int currentNumberOfRooms = 0;
    private bool createdExit = false;

    private GameObject currentPiece;
    private GameObject previousPiece;

    // Start is called before the first frame update
    void Start()
    {
        currentDungeonType = dungeonTypes[Random.Range(0, dungeonTypes.Count)];
        currentPiece = Instantiate(currentDungeonType.dungeonEntrancesExits[Random.Range(0, currentDungeonType.dungeonEntrancesExits.Count)], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentNumberOfRooms < numberOfRooms)
        {
            GenerateDungeon();
        }
        else if(currentNumberOfRooms == numberOfRooms && !createdExit)
        {
            AddPiece(currentDungeonType.dungeonEntrancesExits[Random.Range(0, currentDungeonType.dungeonEntrancesExits.Count)]);
            createdExit = true;
        }
    }

    private void GenerateDungeon()
    {
        ChoosePiece();
        ChooseExit();
        AddPiece(chosenPiece);
        BlockUnusedExits();
    }

    private void ChoosePiece()
    {
        GameObject randomRoom = currentDungeonType.dungeonRooms[Random.Range(0, currentDungeonType.dungeonRooms.Count)];
        GameObject randomCorridor = currentDungeonType.dungeonCorridors[Random.Range(0, currentDungeonType.dungeonCorridors.Count)];

        List<GameObject> pieceList = new List<GameObject>();

        pieceList.Add(randomRoom);
        pieceList.Add(randomCorridor);

        GameObject theChosenPiece = pieceList[Random.Range(0, pieceList.Count)];

        chosenPiece = theChosenPiece;
    }

    private void ChooseExit()
    {

    }

    private bool CheckCollision(GameObject thePiece)
    {
        bool isColliding = false;

        GameObject piece = Instantiate(thePiece, Vector3.zero, Quaternion.identity);
        GameObject currentEntrance = GetEntrance(piece);
        GameObject previousExit = GetExit(previousPiece);
        Vector3 offset;

        offset = currentEntrance.transform.position - piece.transform.position;
        piece.transform.position = previousExit.transform.position - offset;

        GameObject exitParent = previousExit.transform.parent.gameObject;
        previousExit.transform.SetParent(null);
        currentEntrance.transform.SetParent(null);
        piece.transform.SetParent(currentEntrance.transform);
        currentEntrance.transform.rotation = previousExit.transform.rotation;
        piece.transform.SetParent(null);
        currentEntrance.transform.SetParent(piece.transform);
        previousExit.transform.SetParent(exitParent.transform);

        return isColliding;
    }

    private GameObject AddPiece(GameObject thePiece)
    {
        previousPiece = currentPiece;

        GameObject piece = Instantiate(thePiece, Vector3.zero, Quaternion.identity);
        GameObject currentEntrance = GetEntrance(piece);
        GameObject previousExit = GetExit(previousPiece);
        Vector3 offset;

        offset = currentEntrance.transform.position - piece.transform.position;
        piece.transform.position = previousExit.transform.position - offset;

        GameObject exitParent = previousExit.transform.parent.gameObject;
        previousExit.transform.SetParent(null);
        currentEntrance.transform.SetParent(null);
        piece.transform.SetParent(currentEntrance.transform);
        currentEntrance.transform.rotation = previousExit.transform.rotation;
        piece.transform.SetParent(null);
        currentEntrance.transform.SetParent(piece.transform);
        previousExit.transform.SetParent(exitParent.transform);

        currentPiece = piece;

        if(piece.gameObject.tag == "Room")
        {
            currentRoom = piece;
            currentNumberOfRooms++;
        }

        return piece;
    }

    private void BlockUnusedExits()
    {

    }

    // Finds all objects on the piece with the tag 'Exit', puts them into a list and picks a random entrance from the list to use as the exit.
    private GameObject GetExit(GameObject piece)
    {
        List<GameObject> listOfExitObjectsInPiece = new List<GameObject>();

        foreach(Transform child in piece.transform)
        {
            if(child.tag == "Exit")
            {
                listOfExitObjectsInPiece.Add(child.gameObject);
            }
        }

        GameObject exit = listOfExitObjectsInPiece[Random.Range(0, listOfExitObjectsInPiece.Count)];

        return exit;
    }

    // Finds all objects on the piece with the tag 'Entrance', puts them into a list and picks a random entrance from the list to use as the entrance.
    private GameObject GetEntrance(GameObject piece)
    {
        List<GameObject> listOfEntranceObjectsInPiece = new List<GameObject>();

        foreach(Transform child in piece.transform)
        {
            if(child.tag == "Entrance")
            {
                listOfEntranceObjectsInPiece.Add(child.gameObject);
            }
        }

        GameObject entrance = listOfEntranceObjectsInPiece[Random.Range(0, listOfEntranceObjectsInPiece.Count)];

        return entrance;
    }
}
