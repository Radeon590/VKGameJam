using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskView : MonoBehaviour
{
    [SerializeField] private Sprite equalsSprite;
    [SerializeField] private Sprite doneSprite;
    [SerializeField] private Sprite plusSprite;
    [Space]
    [SerializeField] private GameObject recipeElementPref;
    [Space]
    [SerializeField] private GameObject littleRecipe;
    [SerializeField] private Transform littleRecipeGroup;
    [Space]
    [SerializeField] private GameObject bigRecipe;
    [SerializeField] private Transform bigRecipeHeaderGroup;
    [SerializeField] private Transform bigRecipeGroup;
    [Space]
    [SerializeField] private GameObject linePref;

    private List<Meal> _orderList = new List<Meal>();

    public List<Meal> OrderList
    {
        set 
        {
            Debug.Log("list cloning");
            _orderList = new List<Meal>(value);
            Debug.Log(_orderList.Count);
            while(littleRecipeGroup.childCount > 0)
            {
                Destroy(littleRecipeGroup.GetChild(0).gameObject);
                Destroy(bigRecipeHeaderGroup.GetChild(0).gameObject);
            }
            AddHeaderSprites(doneSprite);
            AddHeaderSprites(equalsSprite);
            for(int i = 0; i < _orderList.Count; i++)
            {
                var meal = _orderList[i];
                if(i!=0)
                    AddHeaderSprites(plusSprite);
                AddHeaderSprites(meal.Icon);
                //
                Transform newLineTransform = Instantiate(linePref, bigRecipeGroup).transform;
                AddSpriteToParent(meal.Icon, newLineTransform);
                AddSpriteToParent(equalsSprite, newLineTransform);
                foreach (var mealComponent in meal.MealComponents)
                {
                    AddSpriteToParent(mealComponent.Sprite, newLineTransform);
                    AddSpriteToParent(plusSprite, newLineTransform);
                }
                Destroy(newLineTransform.GetChild(newLineTransform.childCount - 1).gameObject);
            }
            ShowLittleRecipe();
        }
    }

    public Meal MealDone 
    { 
        set 
        {
            int index = _orderList.IndexOf(value);
            littleRecipeGroup.GetChild(1 + (index + 1) * 2);
            bigRecipeHeaderGroup.GetChild(1 + (index + 1) * 2);
            Transform bigGroupLineTransform = bigRecipeGroup.GetChild(index);
            for(int i = 0; i < bigGroupLineTransform.childCount; i++)
            {
                Image elementImage = bigGroupLineTransform.GetChild(i).GetComponent<Image>();
                elementImage.color = new Color(elementImage.color.r, elementImage.color.g, 
                    elementImage.color.b, elementImage.color.a / 2);
            }
        } 
    }

    private void AddSpriteToParent(Sprite sprite, Transform parentTransform)
    {
        Instantiate(recipeElementPref, parentTransform).GetComponent<Image>().sprite = sprite;
    }

    private void AddHeaderSprites(Sprite sprite)
    {
        AddSpriteToParent(sprite, littleRecipeGroup);
        AddSpriteToParent(sprite, bigRecipeHeaderGroup);
    }

    public void ShowLittleRecipe()
    {
        littleRecipe.gameObject.SetActive(true);
        bigRecipe.gameObject.SetActive(false);
    }

    public void ShowFullRecipe()
    {
        littleRecipe.gameObject.SetActive(false);
        bigRecipe.gameObject.SetActive(true);
    }
}
