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
		return _dataHandler.LoadCurrencyWallet();
	}
}
