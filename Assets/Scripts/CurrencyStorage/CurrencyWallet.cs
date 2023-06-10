using System.Collections.Generic;

public class CurrencyWallet
{
	private Dictionary<CurrencyType, int> _currencies;

	public CurrencyWallet(Dictionary<CurrencyType, int> currencies)
	{
		_currencies = currencies;
	}

	public bool TryToSpendCurrencyTypeValue(KeyValuePair<CurrencyType, int> typeValue)
	{
		if (_currencies.ContainsKey(typeValue.Key) && _currencies[typeValue.Key] >= typeValue.Value)
		{
			_currencies[typeValue.Key] -= typeValue.Value;
			return true;
		}
		return false;
	}

	public void AddType(CurrencyType type)
	{
		_currencies.Add(type, 0);
	}
}