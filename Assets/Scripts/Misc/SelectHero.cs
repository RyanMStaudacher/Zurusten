using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// This script should go on the object that the player interacts with in order to switch to a different Champion/Class
// Example: If you want the player to click on a potion to switch to an Alchemist, put this script on that potion.
public class SelectHero : MonoBehaviour, IInteractable
{
    public GameObject player;
    public Champion champion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IInteractable.Interact()
    {
        //player.GetComponent<PlayerChampion>().currentChampion = champion;
    }
}
