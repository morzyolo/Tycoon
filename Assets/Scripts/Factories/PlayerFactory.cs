using UnityEngine;

public class PlayerFactory
{
	private readonly Updater _updater;
	private readonly PlayerConfig _playerConfig;
	private readonly CurrencyWallet _currencyWallet;

	public PlayerFactory(Updater updater, PlayerConfig config, CurrencyWallet currencyStorage)
	{
		_updater = updater;
		_playerConfig = config;
		_currencyWallet = currencyStorage;
	}

	public PlayerFacade Create()
	{
		PlayerFacade playerFacade = Object.Instantiate(_playerConfig.PlayerPrefab,
			_playerConfig.SpawnPoint, Quaternion.identity);
		playerFacade.Initialize(_updater, _playerConfig, _currencyWallet);
		return playerFacade;
	}
}
