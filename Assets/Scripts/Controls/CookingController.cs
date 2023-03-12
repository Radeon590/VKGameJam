using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : Controller
{
    public GameObject MainGame;
    public GameObject CookingMiniGame;
    public Inventory Inv;
    public GameObject Player;
    public Sprite DefSprite;
    
    public override void Activate()
    {
        MainGame.SetActive(false);
        CookingMiniGame.SetActive(true);
    }
    
    public override void Deactivate()
    {
        var dvitems = FindObjectsByType<DropValidItem>(FindObjectsSortMode.None);
        foreach (var variable in dvitems)
        {
            List<GameObject> components = variable.AttachedItems;
            Meal n = new Meal();
            n.MealComponents = new List<MealComponent>();
            foreach (var i in components)
            {
                Debug.Log(i.GetComponent<DragableMealComponent>().Comp);
                n.MealComponents.Add(i.GetComponent<DragableMealComponent>().Comp);
            }

            n.Icon = DefSprite;
            
            Inv.ItemInHand = n;
        }
        MainGame.SetActive(true);
        CookingMiniGame.SetActive(false);
        Player.transform.Translate(Vector2.down * 1);
    }
}
