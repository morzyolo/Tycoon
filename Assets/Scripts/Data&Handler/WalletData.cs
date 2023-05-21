using System.Collections.Generic;

[System.Serializable]
public class WalletData
{
	public Dictionary<CurrencyType, int> Currencies { get; set; }

	public WalletData(Dictionary<CurrencyType, int> currencies)
	{
		Currencies = currencies;
	}
}
