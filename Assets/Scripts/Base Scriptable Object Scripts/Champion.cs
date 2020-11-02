using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Champion", menuName = "Champion", order = 51)]
public class Champion : ScriptableObject
{
    public string championName = "Default";
    public float startingHealth = 100f;
}
