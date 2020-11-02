using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : ScriptableObject
{
    public abstract void Use(PlayerChampionController controller);
}
