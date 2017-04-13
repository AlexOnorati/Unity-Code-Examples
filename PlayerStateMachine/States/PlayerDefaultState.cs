public class PlayerDefaultState : IPlayerState {

    private PlayerStateMachine player;

    public PlayerDefaultState(PlayerStateMachine player) {
        this.player = player;
    }

    public void UpdateState() {

    }
}
