using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMovement : IController {

    public override float GetHorizontal() {
        return 0f;
    }

    public override float GetVertical() {
        return 0f;
    }
}
