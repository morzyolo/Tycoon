using System.Collections.Generic;

public class WalletDataWrapper
{
	public Dictionary<CurrencyType, int> Currencies { get; set; }

	public WalletDataWrapper(Dictionary<CurrencyType, int> currencies) => Currencies = currencies;
}
