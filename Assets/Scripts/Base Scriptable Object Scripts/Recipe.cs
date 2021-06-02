using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    public GameObject potionPrefab;
    public List<ingredient> recipe = new List<ingredient>();
}
