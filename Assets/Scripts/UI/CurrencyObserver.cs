using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class CurrencyObserver : MonoBehaviour
{
	[SerializeField] private CurrencyElement _currencyElementPrefab;
	[SerializeField] private List<CurrencyData> _currenciesData;

	private CurrencyWallet _currencyWallet;

	private Dictionary<CurrencyType, CurrencyElement> _currencyElements;

	private void Awake()
	{
		_currencyElements = new Dictionary<CurrencyType, CurrencyElement>();
	}

	public void Initialize(CurrencyWallet currencyWallet)
	{
		_currencyWallet = currencyWallet;

		_currencyWallet.CurrencyChanged += ChangeCurrencyElement;
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
		var element = Instantiate(_currencyElementPrefab);
		element.Initialize(FindCurrencyUISprite(type), value);
		element.transform.SetParent(transform);
		element.transform.SetSiblingIndex((int)type);
		_currencyElements.Add(type, element);
	}

	private Sprite FindCurrencyUISprite(CurrencyType type)
	{
		foreach (var data in _currenciesData)
			if (data.Type == type)
				return data.UISprite;
		return null;
	}

	private void OnDisable()
	{
		_currencyWallet.CurrencyChanged -= ChangeCurrencyElement;
	}
}