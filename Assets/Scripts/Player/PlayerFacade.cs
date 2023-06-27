using UnityEngine;

public class PlayerFacade : MonoBehaviour
{
	[SerializeField] private PlayerInteraction _inrteraction;
	[SerializeField] private PlayerContainer _container;
	[SerializeField] private PlayerMovement _movement;
	[SerializeField] private Tray _tray;

	public void Initialize(Updater updater, PlayerConfig config, CurrencyWallet currencyWallet)
	{
		_tray.Initialize();
		_container.Initialize(_tray, currencyWallet);
		_inrteraction.Initialize(_container);
		_movement.Initialize(config, updater);
	}

	public void ChangeDirection(Vector2 direction)
		=> _movement.ChangeDirection(new Vector3(direction.x, 0, direction.y));
}
