public class CurrencyWalletFactory
{
	private readonly FileDataHandler _dataHandler;

	public CurrencyWalletFactory(FileDataHandler dataHandler)
	{
		_dataHandler = dataHandler;
	}

	public CurrencyWallet Create()
	{
		WalletData walletData = _dataHandler.LoadWalletData();

		return new CurrencyWallet(walletData.Currencies);
	}
}
