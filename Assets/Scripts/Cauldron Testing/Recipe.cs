using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Recipe", menuName = "Potion Recipe", order = 61)]
public class Recipe : ScriptableObject
{
    public GameObject potionPrefab;
    public List<ingredient> recipe = new List<ingredient>();
}
