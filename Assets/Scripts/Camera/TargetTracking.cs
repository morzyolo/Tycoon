using UnityEngine;

public class TargetTracking : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothTime;
	[SerializeField] private Vector3 _offset;

	private Vector3 _velocity;

	private void FixedUpdate()
	{
		Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, _target.position.z) + _offset;
		Debug.Log(targetPosition + "   " + _target.position);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
	}
}
