using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    weapon,
    Armor,
    Consumable,
    Etc
}
[CreateAssetMenu(fileName = "Item_", menuName = "ShootingGame/Item Data")]
public class ItemData : ScriptableObject
{
    public string ItemId;
    public string ItemName;
    public ItemType ItemType;
    public Sprite icon;
    public int attackBonus;
    public int defenseBonus;
    public bool canStack = true;
    public int maxStack = 99;

}
