using UnityEngine;

public class PlayerFacade : MonoBehaviour
{
	[SerializeField] private PlayerMovement _movement;

	private CurrencyWallet _currencyStorage;

	public void Initialize(Updater updater, PlayerConfig config, CurrencyWallet currencyStorage)
	{
		_movement.Initialize(config, updater, transform);
		_currencyStorage = currencyStorage;
	}

	public void ChangeDirection(Vector2 direction)
		=> _movement.ChangeDirection(new Vector3(direction.x, 0, direction.y));
}
