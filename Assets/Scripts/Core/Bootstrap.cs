using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private PlayerConfig _playerConfig;

	[SerializeField] private TargetTracking _camera;
	[SerializeField] private InputSystem _input;

	[SerializeField] private Updater _updater;

	private void Awake()
	{
		var dataHandler = new FileDataHandler();
		var currenceStorageFactory = new CurrencyWalletFactory(dataHandler);
		var currencyWallet = currenceStorageFactory.Create();

		var playerFactory = new PlayerFactory(_updater, _playerConfig, currencyWallet);
		var player = playerFactory.Create();

		_camera.Initialize(player.transform, _updater);
		_input.Initialize(player);
	}
}
