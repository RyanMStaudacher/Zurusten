using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SelectHero : MonoBehaviour, IInteractable
{
    public GameObject player;
    public string heroClassName;
    public Character heroCharacter;

    private IHero heroScript;
    private string scriptName;

    // Start is called before the first frame update
    void Start()
    {
        //heroScript = this.transform.GetComponent<IHero>();
        //scriptName = heroScript.ReturnName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IInteractable.Interact()
    {
        //player.AddComponent(Type.GetType(scriptName));

        if(Type.GetType(heroClassName) != null)
        {
            //player.AddComponent(Type.GetType(heroClassName));
            player.GetComponent<Testing>().theSelectedCharacter = heroCharacter;
        }
    }
}
