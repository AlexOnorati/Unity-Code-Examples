using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalController : IController {

    public override float GetHorizontal() {
        return 0f;
    }

    public override float GetVertical() {
        return Input.GetAxisRaw("Vertical");
    }
}
