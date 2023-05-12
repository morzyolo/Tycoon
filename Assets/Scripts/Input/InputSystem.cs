using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
	[SerializeField] private PlayerMovement _playerMovement;

	private PlayerInputActions _inputActions;

	private void Awake()
	{
		_inputActions = new PlayerInputActions();
	}

	private void Start()
	{
		_inputActions.Enable();
	}

	private void ChangePlayerDirection(InputAction.CallbackContext context)
		=> _playerMovement.ChangeDirection(context.ReadValue<Vector2>());

	private void StopPlayer(InputAction.CallbackContext context)
		=> _playerMovement.ChangeDirection(Vector2.zero);

	private void OnEnable()
	{
		_inputActions.Player.Move.performed += ChangePlayerDirection;
		_inputActions.Player.Move.canceled += StopPlayer;
	}

	private void OnDisable()
	{
		_inputActions.Player.Move.performed -= ChangePlayerDirection;
		_inputActions.Player.Move.canceled -= StopPlayer;
	}
}