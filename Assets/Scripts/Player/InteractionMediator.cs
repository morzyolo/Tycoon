using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class InteractionMediator
{
	private readonly float _moveSpeed = 2f;
	private readonly float _controlPointHeight = 3f;
	private readonly List<Transform> _endPoints;

	public InteractionMediator()
	{
		_endPoints = new List<Transform>();
	}

	public void InteractDispenserWithStorage(IDispenser dispenser, IStorage storage)
	{
		if (!storage.HasFreeSpace) return;

		if (dispenser.TryDispensingInStorage(out var item, storage))
			MoveItem(storage, item);
	}

	private async void MoveItem(IStorage to, Item item)
	{
		Vector3 startPoint = item.transform.position;
		item.transform.parent = null;

		Transform endPoint = GetFreePoint();
		to.PlaceItemPoint(endPoint);

		Vector3 controlPoint = Vector3.Lerp(startPoint, endPoint.position, 0.5f);
		controlPoint.y += _controlPointHeight;

		float t = 0f;
		while (t < 1)
		{
			await UniTask.Yield();
			t += _moveSpeed * Time.deltaTime;
			item.transform.position = GetCurvePoint(startPoint, endPoint.position, controlPoint, t);
		}

		to.PlaceItem(item, endPoint);
		endPoint.parent = null;
	}

	private Vector3 GetCurvePoint(Vector3 from, Vector3 to, Vector3 controlPoint, float t)
		=> Vector3.Lerp(
			Vector3.Lerp(from, controlPoint, t),
			Vector3.Lerp(controlPoint, to, t),
			t);

	private Transform GetFreePoint()
	{
		foreach (var tr in _endPoints)
			if (tr.parent == null) return tr;

		Transform point = new GameObject("Point").transform;
		_endPoints.Add(point);
		return point;
	}
}
