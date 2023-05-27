using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileDataHandler
{
	private readonly string _dataPath = Application.dataPath;
	private readonly string _walletDataPath = Application.dataPath + Path.AltDirectorySeparatorChar + "Data/walletdata.json";

	public WalletData LoadWalletData()
	{
		if (!File.Exists(_walletDataPath))
			Directory.CreateDirectory(_dataPath + Path.AltDirectorySeparatorChar + "Data");

		string json;
		using (FileStream fileStream = new(_walletDataPath, FileMode.OpenOrCreate))
		{
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, buffer.Length);
			json = Encoding.Default.GetString(buffer);
		}
		WalletData walletData = JsonUtility.FromJson<WalletData>(json);

		return walletData ?? new WalletData(new Dictionary<CurrencyType, int>() { { CurrencyType.Particle, 0 } });
	}

	public void SaveWalletData(Dictionary<CurrencyType, int> currencies)
	{
		WalletData data = new(currencies);

		byte[] buffer = Encoding.Default.GetBytes(JsonUtility.ToJson(data));

		using FileStream fileStream = new(_walletDataPath, FileMode.OpenOrCreate);
		fileStream.Write(buffer, 0, buffer.Length);
	}
}