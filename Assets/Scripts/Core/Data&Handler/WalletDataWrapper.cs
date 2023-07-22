using System.Collections.Generic;

public class WalletDataWrapper
{
	public Dictionary<CurrencyType, uint> Currencies { get; set; }

	public WalletDataWrapper(Dictionary<CurrencyType, uint> currencies) => Currencies = currencies;
}
