using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    private GameObject objectToPlace;
    private ARSessionOrigin _sessionOrigin;
    private Pose objectPose;
    private ARRaycastManager _raycastManager;
    private bool _poseIsValid = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePose();
        if (objectToPlace)
        {
            MoveObjectToPose();    
        }
        
    }

    public void SetObjectLocation()
    {
        if(_poseIsValid)
        {
            var placedObject = Instantiate(objectToPlace, objectPose.position, objectPose.rotation);
            placedObject.transform.parent = gameObject.transform;
        }
        
    }

    private void MoveObjectToPose()
    {
        if (_poseIsValid)
        {
            objectToPlace.SetActive(true);
            objectToPlace.transform.SetPositionAndRotation(objectPose.position, objectPose.rotation);
        }
        else
        {
            objectToPlace.SetActive(false);
        }
    }

    private void UpdatePose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        _poseIsValid = hits.Count > 0;
        if (_poseIsValid)
        {
            Debug.Log("PoseIsValid");
            objectPose = hits[0].pose;
            var cameraForward = Camera.main.transform.forward;
            var camBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            objectPose.rotation = Quaternion.LookRotation(camBearing);
        }
    }

    public void SetObjectToPlace(GameObject inObjectToPlace)
    {
        Destroy(objectToPlace);
        objectToPlace = Instantiate(inObjectToPlace, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
        objectToPlace.transform.parent = gameObject.transform;
    }
}
