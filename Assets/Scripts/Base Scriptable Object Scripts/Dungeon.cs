using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dungeon", menuName = "Dungeon", order = 63)]
public class Dungeon : ScriptableObject
{
    public List<GameObject> dungeonSections = new List<GameObject>();
}
