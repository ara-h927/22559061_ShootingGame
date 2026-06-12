using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public int bagSlotCount = 12;
    public int equipSlotCount = 3;

    public List<InventoryItem> bagItems = new List<InventoryItem>();
    public List<InventoryItem> equipItems = new List<InventoryItem>();


    public void FillEmptySlots(List<InventoryItem> list, int slotCount)
    {
        while (list.Count < slotCount)
        {
            list.Add(null);
        }
    }


    private void Awake()
    {
        Instance = this;
        // bagItems와 equipItems를 슬롯 수만큼 null로 채우기

        bagItems.Clear();
        equipItems.Clear();

        FillEmptySlots(bagItems, bagSlotCount);
        FillEmptySlots(equipItems, equipSlotCount);
    }
    public bool AddItem(ItemData itemData, int count = 1)
    {
        if (itemData == null) return false;
        if (count <= 0) return false;

        if (itemData.canStack)
        {
            for (int i = 0; i < bagItems.Count; i++)
            {
                InventoryItem item = bagItems[i];

                if (item != null && item.data == itemData && item.count < itemData.maxStack)
                {
                    int addCount = Mathf.Min(count, itemData.maxStack - item.count);
                    item.count += addCount;
                    count -= addCount;

                    if (count <= 0)
                    {
                        Debug.Log(itemData.ItemName + "스택 추가 성공");
                        return true;
                    }
                }

            }

        }
        // 같은 아이템이 있으면 개수 누적
        // 빈 칸을 찾아 새 아이템 넣기
        for (int i = 0; i < bagItems.Count; i++)
        {
            if (bagItems[i] == null || bagItems[i].data == null)
            {
                int addCount = itemData.canStack ? Mathf.Min(count, itemData.maxStack) : 1;

                bagItems[i] = new InventoryItem(itemData, addCount);
                count -= addCount;

                Debug.Log(itemData.ItemName + "새 슬롯에 추가 성공");

                if (count <= 0)
                {
                    return true;
                }
            }
        }
        return false;
    }




    public void MoveItem(List<InventoryItem> fromList, int fromIndex, List<InventoryItem> toList, int toIndex)
    {
        // from 슬롯과 to 슬롯의 아이템을 서로 바꾸기
    }
}
