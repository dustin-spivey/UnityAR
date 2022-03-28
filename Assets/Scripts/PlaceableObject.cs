using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlaceableObject : MonoBehaviour
{
    public GameObject placeableObject;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 size;
    public string info;
}
