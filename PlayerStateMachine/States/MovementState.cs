using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : IPlayerState {

    PlayerStateMachine playerMachine;

    public MovementState(PlayerStateMachine playerMachine) {
        this.playerMachine = playerMachine;
    }

    public void UpdateState() {
        float xAxis = playerMachine.currentController.GetHorizontal();
        float yAxis = playerMachine.currentController.GetVertical();

        playerMachine.playerRigidbody.velocity = new Vector3((int)xAxis, (int)yAxis, 0) * playerMachine.speed;
    }
}
