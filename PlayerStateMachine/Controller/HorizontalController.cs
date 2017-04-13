using UnityEngine;

public class HorizontalController : IController {

    public override float GetHorizontal() {
        return Input.GetAxisRaw("Horizontal");
    }

    public override float GetVertical() {
        return 0f;
    }
}
