using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAbilityManager : MonoBehaviour, IInteractable
{
    public List<Recipe> recipeList = new List<Recipe>();
    public List<ingredient> addedIngredients = new List<ingredient>();

    private List<Recipe> potentialMatches = new List<Recipe>();
    private int numberOfAddedIngredients = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //If ingredient has not already been added, add as a new ingredient. If this ingredient has been added before, increase the ingredient amount.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ingredient>() != null)
        {
            Ingredient newIngredient = other.gameObject.GetComponent<Ingredient>();
            bool hasBeenAdded = false;

            foreach (ingredient i in addedIngredients)
            {
                if (newIngredient.ingredientName == i.ingredientName)
                {
                    i.ingredientAmount += newIngredient.ingredientAmount;
                    hasBeenAdded = true;
                    Destroy(other.gameObject);
                }
            }

            if(!hasBeenAdded)
            {
                addedIngredients.Add(other.gameObject.GetComponent<Ingredient>().ingredientInstance);
                Destroy(other.gameObject);
            }
        }
    }

    //Creates a list of recipes that have the same amount of ingredients for use in the brew function so we don't have to iterate through every single recipe every single time.
    private void GetPotentialMatches()
    {
        int numberOfIngredientsInRecipe = 0;

        foreach (ingredient i in addedIngredients)
        {
            numberOfAddedIngredients++;
        }

        foreach (Recipe r in recipeList)
        {
            foreach (ingredient i in r.recipe)
            {
                numberOfIngredientsInRecipe++;
            }

            if (numberOfAddedIngredients == numberOfIngredientsInRecipe)
            {
                potentialMatches.Add(r);
            }

            numberOfIngredientsInRecipe = 0;
        }
    }

    private void Brew()
    {
        foreach(Recipe r in potentialMatches)
        {
            int matchingIngredients = 0;

            foreach (ingredient i in r.recipe)
            {
                foreach (ingredient ing in addedIngredients)
                {
                    if(ing.ingredientName == i.ingredientName && ing.ingredientAmount == i.ingredientAmount)
                    {
                        matchingIngredients++;
                    }
                }
            }

            if(matchingIngredients == r.recipe.Count)
            {
                Debug.Log("The potion you are trying to make is..." + r.ToString() + "!");
            }
        }

        potentialMatches.Clear();
        addedIngredients.Clear();
        numberOfAddedIngredients = 0;
    }

    public void Interact()
    {
        GetPotentialMatches();
        Brew();
    }
}
