using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

    [HideInInspector]
    public PlayerDefaultState defaultState;
    [HideInInspector]
    public MovementState movementState;
    [HideInInspector]
    public Rigidbody playerRigidbody;

    [HideInInspector]
    public MovementController movementController;
    [HideInInspector]
    public HorizontalController horizontalController;
    [HideInInspector]
    public VerticalController verticalController;

    public float speed;

    
    public IController currentController;

    private IPlayerState currentState;
    

    void Awake () {
        playerRigidbody = GetComponent<Rigidbody>();
        defaultState = new PlayerDefaultState(this);
        movementState = new MovementState(this);
        movementController = GetComponent<MovementController>();
        verticalController = GetComponent<VerticalController>();
        horizontalController = GetComponent<HorizontalController>();
    }

	void Start () {
        currentState = movementState;
        
	}

    void FixedUpdate() {
        currentState.UpdateState();
    }
}
