using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    RectTransform rect;
    int RectPosition;
    public bool IsInv = false;

    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
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
    public void Additem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }
    public void InvUIOn()
    {
        IsInv = !IsInv;
    }
}
