using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IFixedUpdateListener
{
	private float _normalSpeed;
	private float _rotationSpeed;

	private float _currentSpeed;
	private Rigidbody _rigidbody;
	private Vector3 _moveDirection;

	public void Initialize(PlayerConfig config, Updater updater)
	{
		updater.AddListener(this);
		_normalSpeed = config.NormalSpeed;
		_rotationSpeed = config.RotationSpeed;
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
		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			Quaternion.Euler(0f, Mathf.Atan2(-_moveDirection.z, _moveDirection.x) * Mathf.Rad2Deg, 0f),
			_rotationSpeed * Time.deltaTime);
		_rigidbody.MovePosition(transform.position + _currentSpeed * Time.deltaTime * _moveDirection);
	}

	public void ChangeDirection(Vector3 direction) => _moveDirection = direction;
}
