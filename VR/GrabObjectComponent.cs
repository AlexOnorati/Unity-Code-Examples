using UnityEngine;
using UnityEngine.Events;

///<author>Alex Onorati</author>
/// <summary>
/// Attach to an object inorder to be able to interact with it.
/// </summary>
public class GrabObjectComponent : MonoBehaviour {

    public bool isMovable;
    public bool beingHeld;
    public VRController controller;
    public bool updatePosition;
    public Vector3 position;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public UnityEvent onGrab;
    public UnityEvent onRelease;
    public UnityEvent onButtonTrigger;
    public Transform target;

    void Awake() {
       
        if (target == null) {
            DebugManager.Log(DebugType.VR, "Getting target");
            target = transform;
        }
    }

    //Sets the object to movable
    public void SetMovable(bool value) {
        isMovable = value;
    }

    //Runs events based on the controller input.
    public GrabObjectComponent OnGrab(VRController controller) {
        if (controller.GetButton(triggerButton))
        {
            onButtonTrigger.Invoke();
            if (beingHeld && this.controller == controller)
            {
                onRelease.Invoke();
                return null;
            }
            this.controller = controller;

            onGrab.Invoke();
            return this;
        }
        else {
            return controller.currentComponent;
        }
    }

    /// <summary>
    /// Attaches the object to the controller.
    /// </summary>
    public void AttachObject() {
        if (beingHeld)
        {
            this.controller.currentComponent = null;
        }
        beingHeld = true;

        
        target.SetParent(controller.transform);
        if (updatePosition)
        {
            target.localPosition = position;
        }
    }

    /// <summary>
    /// Removes the connection to the controller.
    /// </summary>
    public void OnRelease() {

        controller.currentComponent = null;
        beingHeld = false;
        target.SetParent(null);
    }
}
