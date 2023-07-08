using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private PlayerConfig _playerConfig;
	[SerializeField] private List<CurrencyData> _currenciesData;
	[Space(15)]
	[SerializeField] private CurrencyObserver _currencyObserver;
	[SerializeField] private FactoryProgress _factoryProgress;
	[SerializeField] private TargetTracking _camera;
	[SerializeField] private InputSystem _input;
	[SerializeField] private Updater _updater;

	private FileDataHandler _fileHandler;

	private void Awake()
	{
		_fileHandler = new FileDataHandler();
		_fileHandler.Initialize();
		_factoryProgress.Initialize(_fileHandler);

		var currencyWalletFactory = new CurrencyWalletFactory(_fileHandler);
		var currencyWallet = currencyWalletFactory.Create();
		_currencyObserver.Initialize(currencyWallet, _currenciesData);
		var playerFactory = new PlayerFactory(_updater, _playerConfig, currencyWallet);
		var player = playerFactory.Create();
		_input.Initialize(player);
		_camera.Initialize(player.transform, _updater);

		currencyWallet.InitializeSubs();
	}
}
