using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Throw Potion", menuName = "Ability/Alchemist/Main/Throw Potion", order = 61)]
public class ThrowPotion : Ability
{
    public GameObject potionPrefab;
    public Camera player;

    private GameObject potion;
    private Rigidbody prb;

    public override void Use(PlayerChampionController controller)
    {
        player = Camera.main;

        potion = Instantiate(potionPrefab, player.transform.position, Quaternion.identity);
        prb = potion.GetComponent<Rigidbody>();
    }
}
