using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dungeon", menuName = "Dungeon", order = 4)]
public class Dungeon : ScriptableObject
{
    public List<GameObject> dungeonRooms = new List<GameObject>();
    public List<GameObject> dungeonCorridors = new List<GameObject>();
    public List<GameObject> dungeonEntrancesExits = new List<GameObject>();
}
