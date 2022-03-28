using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaver : MonoBehaviour
{
    private PlaceableObject _po;
    // Start is called before the first frame update
    void Start()
    {
        _po = this.GetComponent<PlaceableObject>();
        _po.info = "This object is cool";
        SaveObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SaveObject();
        }
    }

    void SaveObject()
    {
        _po.position = transform.position;
        _po.rotation = transform.rotation;
        _po.size = transform.localScale;
        string json = JsonUtility.ToJson(_po);
        Debug.Log(json);
    }
}
