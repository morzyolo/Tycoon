using UnityEngine;

public class PlayerFacade : MonoBehaviour
{
	[SerializeField] private PlayerInteraction _inrteraction;
	[SerializeField] private PlayerMovement _movement;

	private CurrencyWallet _currencyWallet;

	public void Initialize(Updater updater, PlayerConfig config, CurrencyWallet currencyWallet)
	{
		_inrteraction.Initialize(_currencyWallet);
		_movement.Initialize(config, updater, transform);
		_currencyWallet = currencyWallet;
	}

	public void ChangeDirection(Vector2 direction)
		=> _movement.ChangeDirection(new Vector3(direction.x, 0, direction.y));
}
