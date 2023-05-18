using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
	[SerializeField] private PlayerFacade _player;

	private PlayerInputActions _inputActions;

	public void Initialize(PlayerFacade player)
	{
		_player = player;
		_inputActions = new PlayerInputActions();
	}

	private void Start()
	{
		_inputActions.Enable();
	}

	private void ChangePlayerDirection(InputAction.CallbackContext context)
		=> _player.ChangeDirection(context.ReadValue<Vector2>());

	private void StopPlayer(InputAction.CallbackContext context)
		=> _player.ChangeDirection(Vector2.zero);

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