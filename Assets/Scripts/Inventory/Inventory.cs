using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject droppedItemPrefab;
    [SerializeField] private Image itemInHandIcon;
    //
    private Item _itemInHand;

    public Item ItemInHand
    {
        get { return _itemInHand; } 
        set 
        { 
            _itemInHand = value;
            if (_itemInHand != null)
            {
                itemInHandIcon.sprite = _itemInHand.Icon;
            }
            else
                itemInHandIcon.sprite = null;
        }
    }

    public void DropItem()
    {
        GameObject droppedItem = Instantiate(this.droppedItemPrefab, this.transform.position, this.transform.rotation);
        droppedItem.name = ItemInHand.Namespace;
        droppedItem.GetComponent<SpriteRenderer>().sprite = ItemInHand.Icon;
        ItemInHand = null;
    }

    [SerializeField] private Item testItem;

    private void Start()
    {
        ItemInHand = testItem;
        DropItem();
    }
}
