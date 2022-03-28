using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/Placeable Object", fileName = "PlaceableObject.asset")]
public class InventoryItem : ScriptableObject
{
   public string itemName;
   public GameObject placeableObjectPrefab;
}
