using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int numberOfRooms = 10;
    public GameObject theRoom;

    private int rooms = 0;
    private List<GameObject> roomExits = new List<GameObject>();
    private GameObject newRoom;
    private GameObject newRoomEntrance;
    private GameObject startingPiece;
    private GameObject currentPiece;
    private GameObject previousPiece;

    // Start is called before the first frame update
    void Start()
    {
        startingPiece = Instantiate(theRoom, Vector3.zero, Quaternion.identity);
        previousPiece = startingPiece;
    }

    // Update is called once per frame
    void Update()
    {
        if (rooms < numberOfRooms - 1)
        {
            PlaceRoom();
        }
    }

    private void PlaceRoom()
    {
        // If there is no currentPiece, then make one, otherwise properly position the currentPiece.
        if (currentPiece == null)
        {
            currentPiece = Instantiate(theRoom, Vector3.zero, Quaternion.identity);
        }
        else if(currentPiece != null)
        {
            // If the previousPiece is the startingPiece, position the currentPiece relative to the startingPiece.
            // Otherwise, position the currentPiece relative to the previousPiece.
            if(previousPiece == startingPiece)
            {
                GameObject startingPieceExit = null;
                GameObject currentPieceEntrance = null;
                Vector3 offset;

                // Looks for the exit gameobject of the startingPiece
                foreach(Transform child in startingPiece.transform)
                {
                    if(child.tag == "Exit")
                    {
                        startingPieceExit = child.gameObject;
                    }
                }

                //Looks for the entrance gameobject of the currentPiece
                foreach(Transform child in currentPiece.transform)
                {
                    if(child.tag == "Entrance")
                    {
                        currentPieceEntrance = child.gameObject;
                    }
                }

                offset = currentPieceEntrance.transform.position - currentPiece.transform.position;
                currentPiece.transform.position = startingPieceExit.transform.position - offset;

                previousPiece = currentPiece;
                currentPiece = null;
                rooms++;
            }
            else if(previousPiece != startingPiece)
            {
                GameObject previousPieceExit = null;
                GameObject currentPieceEntrance = null;
                Vector3 offset;

                // Looks for the exit gameobject of the previousPiece
                foreach(Transform child in previousPiece.transform)
                {
                    if(child.tag == "Exit")
                    {
                        previousPieceExit = child.gameObject;
                    }
                }

                // Looks for the entrance gameobject of the currentPiece
                foreach(Transform child in currentPiece.transform)
                {
                    if(child.tag == "Entrance")
                    {
                        currentPieceEntrance = child.gameObject;
                    }
                }

                offset = currentPieceEntrance.transform.position - currentPiece.transform.position;
                currentPiece.transform.position = previousPieceExit.transform.position - offset;

                previousPiece = currentPiece;
                currentPiece = null;
                rooms++;
            }
        }
    }
}
