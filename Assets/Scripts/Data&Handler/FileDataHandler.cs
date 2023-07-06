using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileDataHandler
{
	private readonly string _dataPath = Application.dataPath;
	private readonly string _walletDataPath = Application.dataPath + Path.AltDirectorySeparatorChar + "Data/walletdata.json";
	private readonly string _boughtNodesPath = Application.dataPath + Path.AltDirectorySeparatorChar + "Data/nodesdata.json";

	public void Initialize()
	{
		if (!File.Exists(_walletDataPath))
			Directory.CreateDirectory(_dataPath + Path.AltDirectorySeparatorChar + "Data");
	}

	public void SaveWallet(Dictionary<CurrencyType, uint> currencies) =>
		SaveJsonData(_walletDataPath,
			JsonConvert.SerializeObject(new WalletDataWrapper(currencies), Formatting.Indented));

	public CurrencyWallet LoadCurrencyWallet()
	{
		string json = LoadJsonData(_walletDataPath);
		var walletWrapper = JsonConvert.DeserializeObject<WalletDataWrapper>(json);

		return walletWrapper != null ?
			new CurrencyWallet(walletWrapper.Currencies) :
			new CurrencyWallet(new Dictionary<CurrencyType, uint>() { { CurrencyType.Coin, 0 } });
	}

	public void SaveBuyableNodes(List<BuyableNode> nodes) =>
		SaveJsonData(_boughtNodesPath,
			JsonUtility.ToJson(new BuyableNodesWrapper(nodes)));

	public List<BuyableNode> LoadBuyableNodes()
	{
		string json = LoadJsonData(_boughtNodesPath);
		var nodesWrapper = JsonUtility.FromJson<BuyableNodesWrapper>(json);

		return nodesWrapper != null ?
			nodesWrapper.BuyableNodes :
			new List<BuyableNode>();
	}

	private string LoadJsonData(string path)
	{
		string json;
		using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
		{
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, buffer.Length);
			json = Encoding.Default.GetString(buffer);
		}
		return json;
	}

	private void SaveJsonData(string path, string json)
	{
		byte[] buffer = Encoding.Default.GetBytes(json);

		using FileStream fileStream = new(path, FileMode.OpenOrCreate);
		fileStream.Write(buffer, 0, buffer.Length);
	}
}