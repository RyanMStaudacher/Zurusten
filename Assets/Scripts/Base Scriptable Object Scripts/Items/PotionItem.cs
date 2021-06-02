using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Item", menuName = "Items/Potion", order = 2)]
public class PotionItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.Potion;
    }
}
