using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject objectPlacer;
    private Ray ray;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Physics.Raycast(ray, out hit);
            if (hit.transform.gameObject.layer != 5) //5 is the UI layer
            {
                if (objectPlacer)
                {
                    objectPlacer.GetComponent<PlaceObject>().SetObjectLocation();
                }
            }
        }
    }
}
