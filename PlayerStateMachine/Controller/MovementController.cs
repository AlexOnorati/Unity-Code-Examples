using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController :  IController{

    public override float GetHorizontal() {
        return Input.GetAxisRaw("Horizontal");
    }

    public override float GetVertical() {
        return Input.GetAxisRaw("Vertical");
    }
}
