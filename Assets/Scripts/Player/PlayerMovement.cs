using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IFixedUpdateListener
{
	private Transform _playerTransform;

	private float _normalSpeed;
	private float _currentSpeed;

	private Rigidbody _rigidbody;
	private Vector3 _moveDirection;

	public void Initialize(PlayerConfig config, Updater updater, Transform player)
	{
		_playerTransform = player;
		updater.AddListener(this);
		_normalSpeed = config.NormalSpeed;
	}

	private void Start()
	{
		_currentSpeed = _normalSpeed;
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void FixedTick(float fixedTime)
	{
		if (_moveDirection.sqrMagnitude > 0.5f)
			Move();
	}

	private void Move()
	{
		_rigidbody.MovePosition(_playerTransform.position + _currentSpeed * Time.deltaTime * _moveDirection);
	}

	public void ChangeDirection(Vector3 direction) => _moveDirection = direction;
}
