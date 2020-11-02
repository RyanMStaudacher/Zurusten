using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Throw Potion", menuName = "Ability/Alchemist/Main/Throw Potion", order = 61)]
public class ThrowPotion : Ability
{
    public override void Use(PlayerChampionController controller)
    {
        Debug.Log("You threw a potion!");
    }
}
