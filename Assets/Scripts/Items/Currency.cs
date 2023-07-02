using System.Collections.Generic;
using UnityEngine;

public class Currency : Item
{
	[SerializeField] private CurrencyType _currencyType;

	public KeyValuePair<CurrencyType, int> GetTypeValue()
	{
		return new KeyValuePair<CurrencyType, int>(_currencyType, 1);
	}
}
