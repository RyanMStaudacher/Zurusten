using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient Object", menuName = "Items/Ingredient", order = 1)]
public class IngredientItem : ItemObject
{
    public string crushedOrDistilledItemName;
    public bool isCrushed = false;
    public bool isDistilled = false;

    public void Awake()
    {
        type = ItemType.Ingredient;
    }
}
