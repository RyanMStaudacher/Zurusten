using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChampionController : MonoBehaviour
{
    public Ability mainAbility;
    public Ability secondaryAbility;
    public Ability ultimateAbility;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseMainAbility();
        UseSecondaryAbility();
    }

    public void UseMainAbility()
    {
        if(Input.GetButtonDown("Main Ability"))
        {
            mainAbility.Use(this);
        }
    }

    public void UseSecondaryAbility()
    {
        if (Input.GetButtonDown("Secondary Ability"))
        {
            secondaryAbility.Use(this);
        }
    }

    public void UseUltimateAbility()
    {
        ultimateAbility.Use(this);
    }
}
