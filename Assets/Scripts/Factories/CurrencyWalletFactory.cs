using System.Collections.Generic;

public class CurrencyWalletFactory
{
	private readonly FileDataHandler _dataHandler;

	public CurrencyWalletFactory(FileDataHandler dataHandler)
	{
		_dataHandler = dataHandler;
	}

	public CurrencyWallet Create()
	{
		WalletDataWrapper walletWrapper = _dataHandler.LoadWalletData();

		return walletWrapper != null ?
			new CurrencyWallet(walletWrapper.Currencies) :
			new CurrencyWallet(new Dictionary<CurrencyType, int>() { { CurrencyType.Coin, 0 } });
	}
}
