using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe Object", menuName = "Item/Recipe", order = 1)]
public class RecipeItem : ItemObject
{
    public List<Ingredient> recipe = new List<Ingredient>();

    public void Awake()
    {
        type = ItemType.Recipe;
    }
}
