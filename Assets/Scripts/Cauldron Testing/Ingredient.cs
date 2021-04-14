using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ingredient : MonoBehaviour
{
    public ingredient ingredientInstance;

    public string ingredientName;
    public float ingredientAmount;

    // Start is called before the first frame update
    void Start()
    {
        ingredientInstance.ingredientName = ingredientName;
        ingredientInstance.ingredientAmount = ingredientAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//A new ingredient class that is serialized for use in the Unity editor.
[System.Serializable]
public class ingredient
{
    public string ingredientName;
    public float ingredientAmount;

    public ingredient(string iName, float iAmount)
    {
        iName = "Empty";
        iAmount = 0.0f;
    }
}
