using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour, IObjectItem
{
    public Item item;
    public SpriteRenderer itemImage;

    void Start()
    {
        itemImage.sprite = item.ItemImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Item ClickItem()
    {
        return this.item;
    }
}
public interface IObjectItem
{
    Item ClickItem();
}
