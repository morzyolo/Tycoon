using UnityEngine;

public class PlayerContainer : MonoBehaviour, IStorage, IDispenser
{
	private Tray _tray;
	private CurrencyWallet _wallet;

	public bool HasFreeSpace => _tray.HasFreeSpace;

	public void Initialize(Tray tray, CurrencyWallet wallet)
	{
		_tray = tray;
		_wallet = wallet;
	}

	public bool TrySpendCurrency(IBuyable buyable)
		=> _wallet.TryToSpendCurrencyTypeValue(buyable.GetCost());

	public bool TryStore(Item item)
	{
		if (item is CarriableItem carriable)
			_tray.Store(carriable);
		else if (item is Currency currency)
			_wallet.AddCurrency(currency.GetTypeValue());
		return true;
	}

	public bool TryDispensingInStorage(out Item item, IStorage storage)
		=> _tray.TryDispensingInStorage(out item, storage);

	public void PlaceItem(Item item, Transform point)
	{
		if (item is CarriableItem cariable)
			_tray.PlaceItem(cariable);
	}

	public void PlaceItemPoint(Transform point)
	{
		point.parent = transform;
		point.localPosition = Vector3.zero;
	}
}