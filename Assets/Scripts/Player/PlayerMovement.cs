using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed;

	private Rigidbody _rigidbody;
	private Vector3 _moveDirection;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (_moveDirection.sqrMagnitude > 0.5f)
			Move();
	}

	private void Move()
	{
		_rigidbody.MovePosition(transform.position + _speed * Time.deltaTime * _moveDirection);
	}

	public void ChangeDirection(Vector2 direction) 
		=> _moveDirection = new Vector3(direction.x, 0, direction.y);
}
