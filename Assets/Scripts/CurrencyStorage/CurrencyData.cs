using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "Currency", order = 3)]
public class CurrencyData : ScriptableObject
{
	[SerializeField] private CurrencyType _type;
	[SerializeField] private Sprite _uiSprite;
	[SerializeField] private Currency _currencyPrefab;

	public CurrencyType Type { get => _type; }
	public Sprite UISprite { get => _uiSprite; }
	public Currency CurrencyPrefab { get => _currencyPrefab; }
}
