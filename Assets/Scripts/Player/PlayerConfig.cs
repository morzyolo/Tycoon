using UnityEngine;

[CreateAssetMenu(menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[SerializeField] private PlayerFacade _playerPrefab;

	[SerializeField] private Vector3 _spawnPoint;
	[SerializeField] private float _normalSpeed;
	[SerializeField] private float _rotationSpeed;

	public PlayerFacade PlayerPrefab { get => _playerPrefab; }
	public Vector3 SpawnPoint { get => _spawnPoint; }
	public float NormalSpeed { get => _normalSpeed; }
	public float RotationSpeed { get => _rotationSpeed; }
}
