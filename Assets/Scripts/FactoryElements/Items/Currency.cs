using System.Collections.Generic;
using UnityEngine;

public class Currency : Item
{
	[SerializeField] private CurrencyType _currencyType;

	public KeyValuePair<CurrencyType, uint> GetTypeValue()
	{
		return new KeyValuePair<CurrencyType, uint>(_currencyType, 1);
	}
}
