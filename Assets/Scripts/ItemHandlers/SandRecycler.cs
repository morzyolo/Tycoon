using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandRecycler : MonoBehaviour, IStorage, IDispenser
{
	public bool HasFreeSpace => _sandForRecycling.Count < _sandCount;

	[SerializeField] private Currency _currencyPrefab;
	[SerializeField] private int _sandCount;

	[SerializeField] private float _recycleTime;
	[SerializeField] private Image _progressImage;

	private Queue<Sand> _sandForRecycling;
	private List<Currency> _currencyStorage;
	private Coroutine _recycleCoroutine;

	private void Start()
	{
		_sandForRecycling = new Queue<Sand>();
		_currencyStorage = new List<Currency>();

		_progressImage.fillAmount = 0;
		_progressImage.transform.localRotation = Camera.main.transform.localRotation;
	}

	public bool TryStore(Item item)
	{
		if (item is Sand sand)
		{
			_sandForRecycling.Enqueue(sand);
			return true;
		}
		else
			return false;
	}

	public void PlaceItem(Item item, Transform point)
	{
		item.transform.parent = transform;
		item.transform.localRotation = Quaternion.identity;
		item.transform.localPosition = point.localPosition;
		TryStartRecycle();
	}

	public void PlaceItemPoint(Transform point)
	{
		point.parent = transform;
		point.localPosition = GetFreeItemPosition();
	}

	public bool TryDispensingInStorage(out Item item, IStorage storage)
	{
		for (int i = 0; i < _currencyStorage.Count; i++)
		{
			if (storage.TryStore(_currencyStorage[i]))
			{
				item = _currencyStorage[i];
				_currencyStorage.RemoveAt(i);
				return true;
			}
		}

		item = null;
		return false;
	}

	private void TryStartRecycle()
	{
		if (_sandForRecycling.Count == 0 || _recycleCoroutine != null) return;
		_recycleCoroutine = StartCoroutine(RecycleItem());
	}

	private IEnumerator RecycleItem()
	{
		while (_sandForRecycling.Count > 0)
		{
			float remainingTime = 0;

			var sand = _sandForRecycling.Dequeue();
			Destroy(sand.gameObject);

			while (remainingTime < _recycleTime)
			{
				remainingTime += Time.deltaTime;
				_progressImage.fillAmount = remainingTime / _recycleTime;
				yield return null;
			}

			_progressImage.fillAmount = 0;
			var currency = Instantiate(_currencyPrefab, transform);
			_currencyStorage.Add(currency);
		}

		_recycleCoroutine = null;
	}

	private Vector3 GetFreeItemPosition()
	{
		return _sandForRecycling.Count * 0.1f * Vector3.up;
	}
}
