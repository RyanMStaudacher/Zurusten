using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drink Potion", menuName = "Ability/Alchemist/Main/Drink Potion", order = 61)]
public class DrinkPotion : Ability
{
    public override void Use(PlayerChampionController controller)
    {
        Debug.Log("You drank a potion!");
    }
}
