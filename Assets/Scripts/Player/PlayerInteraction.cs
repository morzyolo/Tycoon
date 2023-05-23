using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerInteraction : MonoBehaviour
{
	private CurrencyWallet _currencyWallet;

	public void Initialize(CurrencyWallet wallet)
	{
		_currencyWallet = wallet;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IBuyable>(out var buyable))
		{
			if (_currencyWallet.TryToSpendCurrencyTypeValue(buyable.GetCost()))
				buyable.Buy();
		}
	}
}
