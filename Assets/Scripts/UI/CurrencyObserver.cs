using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class CurrencyObserver : MonoBehaviour
{
	[SerializeField] private CurrencyElement _currencyElementPrefab;

	private List<CurrencyData> _currenciesData;
	private CurrencyWallet _currencyWallet;
	private Dictionary<CurrencyType, CurrencyElement> _currencyElements;

	public void Initialize(CurrencyWallet currencyWallet, List<CurrencyData> currenciesData)
	{
		_currencyWallet = currencyWallet;
		_currenciesData = currenciesData;
		_currencyWallet.CurrencyChanged += ChangeCurrencyElement;
		_currencyElements = new Dictionary<CurrencyType, CurrencyElement>();
	}

	private void ChangeCurrencyElement(CurrencyType type, uint value)
	{
		if (_currencyElements.ContainsKey(type))
			_currencyElements[type].ChangeValue(value);
		else
			CreateCurrencyElement(type, value);
	}

	private void CreateCurrencyElement(CurrencyType type, uint value)
	{
		var element = Instantiate(_currencyElementPrefab, transform);
		element.Initialize(FindCurrencyUISprite(type), value);
		element.transform.SetSiblingIndex((int)type);
		_currencyElements.Add(type, element);
	}

	private Sprite FindCurrencyUISprite(CurrencyType type)
	{
		foreach (var data in _currenciesData)
			if (data.Type == type)
				return data.UISprite;

		throw new System.Exception($"Required sprite type \"{type}\" not found");
	}

	private void OnDisable()
	{
		_currencyWallet.CurrencyChanged -= ChangeCurrencyElement;
	}
}