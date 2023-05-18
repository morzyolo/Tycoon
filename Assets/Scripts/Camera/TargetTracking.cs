using UnityEngine;

public class TargetTracking : MonoBehaviour, IFixedUpdateListener
{
	[SerializeField] private Vector2 _maxTargetOffset;
	[SerializeField] private Vector3 _offset;
	[SerializeField] private float _smoothness;

	private Transform _target;

	public void Initialize(Transform target, Updater updater)
	{
		_target = target;
		transform.position = target.position + _offset;
		updater.AddListener(this);
	}

	public void FixedTick(float fixedDeltaTime)
	{
		Vector3 targetPosition = _target.position + _offset;

		if (Mathf.Abs(targetPosition.x - transform.position.x) > _maxTargetOffset.x ||
			Mathf.Abs(targetPosition.z - transform.position.z) > _maxTargetOffset.y)
		{
			transform.position = Vector3.Lerp(transform.position, targetPosition, fixedDeltaTime * _smoothness);
		}
	}

	public void SetTarget(Transform target) => _target = target;
}
