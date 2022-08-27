using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SupplyManager
{
    RectTransform rect;
    public int RectPosition;
    public bool IsInv = false;

    public List<Item> items;

    SupplyManager Sm;

    public Transform slotParent;

    public Slot[] slots;

    private void OnValidate()
    {
       // slots = slotParent.GetComponentsInChildren<Slot>();
    }
    private void Awake()
    {
        FreshSlot();
    }
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        FreshSlot();
        if (IsInv)
            RectPosition = 0;
        else
            RectPosition = -400;
        rect.anchoredPosition = new Vector2(Mathf.Lerp(rect.anchoredPosition.x, RectPosition, 0.05f), -50);
    }
    public void FreshSlot()
    {
        int i = 0;
        for(; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void InvUIOn()
    {
        IsInv = !IsInv;
    }
}
