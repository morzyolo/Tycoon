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

	public void SaveWalletData(Dictionary<CurrencyType, int> currencies) =>
		SaveJsonData(_walletDataPath,
			JsonConvert.SerializeObject(new WalletDataWrapper(currencies), Formatting.Indented));

	public WalletDataWrapper LoadWalletData()
	{
		string json = LoadJsonData(_walletDataPath);
		return JsonConvert.DeserializeObject<WalletDataWrapper>(json);
	}

	public void SaveBuyableNodesData(List<BuyableNode> nodes) =>
		SaveJsonData(_boughtNodesPath,
			JsonUtility.ToJson(new BuyableNodesWrapper(nodes)));

	public List<BuyableNode> LoadBuyableNodesData()
	{
		string json = LoadJsonData(_boughtNodesPath);
		return JsonUtility.FromJson<BuyableNodesWrapper>(json)?.BuyableNodes;
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