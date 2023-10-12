using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Quantum Item Creator",menuName ="QuantumTools/Create a Spawn Item")]
public class ItemScriptableObject : ScriptableObject
{
   public enum ItemType
    {
        Weapons,
        Powers,
        ConsumableItems
    }
    public  ItemType ItemGroup;
    public  string ItemName;
    public  int ItemCount;
    public  GameObject ItemPrefab;

}
