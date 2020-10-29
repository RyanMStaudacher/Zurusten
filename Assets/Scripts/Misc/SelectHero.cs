using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SelectHero : MonoBehaviour, IInteractable
{
    public GameObject player;

    private IHero heroScript;
    private string scriptName;

    // Start is called before the first frame update
    void Start()
    {
        heroScript = this.transform.GetComponent<IHero>();
        scriptName = heroScript.ReturnName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IInteractable.Interact()
    {
        player.AddComponent(Type.GetType(scriptName));
    }
}
