using UnityEngine;

public class PlayerFacade : MonoBehaviour
{
	[SerializeField] private PlayerMovement _movement;

	public void Initialize(PlayerConfig config, Updater updater)
	{
		_movement.Initialize(config, updater, transform);
	}

	public void ChangeDirection(Vector2 direction)
		=> _movement.ChangeDirection(new Vector3(direction.x, 0, direction.y));
}
