using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<author>Alex Onorati</author>
///<summary>
///Keeps track of the player controller. (Currently only supports HTC Vive)
/// </summary>
public class VRController : MonoBehaviour
{
    
    private SteamVR_Controller.Device controller {
        get {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    private SteamVR_TrackedObject trackedObj;
    
    public GrabObjectComponent currentComponent;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void OnTriggerStay(Collider collider) {
        if (collider.CompareTag("PickUp") || collider.CompareTag("Out") || collider.CompareTag("Wire")) {
            DebugManager.Log(DebugType.VR,"Controller has collided with a pickup");
            currentComponent = collider.GetComponent<GrabObjectComponent>().OnGrab(this);
        }
    }

    /// <summary>
    /// Gets button value based on it's output.
    /// </summary>
    /// <param name="button">Controller output</param>
    /// <returns>true or false value.</returns>
    public bool GetButton(Valve.VR.EVRButtonId button) {
        return controller.IsNotNull() ? controller.GetPressDown(button): false;
    }
}
