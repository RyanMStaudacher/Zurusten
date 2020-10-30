using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Character theSelectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theSelectedCharacter != null)
        {
            theSelectedCharacter.characterName = "Georgie";
            print(theSelectedCharacter.characterName);
        }
        else if(theSelectedCharacter == null)
        {
            Debug.Log("There is not a character selected.");
        }
    }
}
