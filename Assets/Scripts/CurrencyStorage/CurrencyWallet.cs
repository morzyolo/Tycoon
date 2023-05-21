using System.Collections.Generic;

public class CurrencyWallet
{
	private Dictionary<CurrencyType, int> _currencies;

	public CurrencyWallet(Dictionary<CurrencyType, int> currencies)
	{
		_currencies = currencies;
	}
}
