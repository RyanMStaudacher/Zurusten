using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Item/Default", order = 1)]
public class DefaultItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
