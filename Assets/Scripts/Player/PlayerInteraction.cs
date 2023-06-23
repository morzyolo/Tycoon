using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerInteraction : MonoBehaviour
{
	private Tray _tray;
	private CurrencyWallet _currencyWallet;

	public void Initialize(CurrencyWallet wallet, Tray tray)
	{
		_tray = tray;
		_currencyWallet = wallet;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<IBuyable>(out var buyable))
		{
			if (_currencyWallet.TryToSpendCurrencyTypeValue(buyable.GetCost()))
				buyable.Buy();
		}

		if (other.TryGetComponent<CarriableItem>(out var carriableItem))
		{
			_tray.TryToCarryItem(carriableItem);
		}
		
		if (other.TryGetComponent<IDispenser>(out var dispenser))
		{
			if (_tray.HasFreeSpace && dispenser.TryDispense(out var item))
			{
				_tray.TryToCarryItem(item);
			}
		}
	}
}
