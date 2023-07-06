using System;
using System.Collections.Generic;

public class CurrencyWallet
{
	public event Action<CurrencyType, uint> CurrencyChanged;

	private readonly Dictionary<CurrencyType, uint> _currencies;

	public CurrencyWallet(Dictionary<CurrencyType, uint> currencies)
	{
		_currencies = currencies;
	}

	public bool TryToSpendCurrencyTypeValue(KeyValuePair<CurrencyType, uint> typeValue)
	{
		if (_currencies.ContainsKey(typeValue.Key) && _currencies[typeValue.Key] >= typeValue.Value)
		{
			ChangeCurrency(typeValue.Key, _currencies[typeValue.Key] - typeValue.Value);
			return true;
		}
		return false;
	}

	public void AddCurrency(KeyValuePair<CurrencyType, uint> typeValue)
	{
		if (_currencies.ContainsKey(typeValue.Key))
			ChangeCurrency(typeValue.Key, _currencies[typeValue.Key] + typeValue.Value);
		else
			AddType(typeValue.Key, typeValue.Value);
	}

	private void ChangeCurrency(CurrencyType type, uint value)
	{
		_currencies[type] = value;
		CurrencyChanged?.Invoke(type, _currencies[type]);
	}

	private void AddType(CurrencyType type, uint value)
	{
		_currencies.Add(type, value);
		CurrencyChanged?.Invoke(type, value);
	}

	public void InitializeSubs()
	{
		foreach (var cur in _currencies)
			CurrencyChanged?.Invoke(cur.Key, cur.Value);
	}
}