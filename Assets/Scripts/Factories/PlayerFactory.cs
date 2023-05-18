using UnityEngine;

public class PlayerFactory
{
	private readonly PlayerConfig _playerConfig;
	private readonly Updater _updater;

	public PlayerFactory(PlayerConfig config, Updater updater)
	{
		_playerConfig = config;
		_updater = updater;
	}

	public PlayerFacade Create()
	{
		PlayerFacade playerFacade = Object.Instantiate(_playerConfig.PlayerPrefab,
			_playerConfig.SpawnPoint, Quaternion.identity);
		playerFacade.Initialize(_playerConfig, _updater);
		return playerFacade;
	}
}
