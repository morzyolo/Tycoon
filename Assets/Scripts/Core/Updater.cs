using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
	private List<IFixedUpdateListener> _fixedUpdateListeners = new();

	private void FixedUpdate()
	{
		foreach (var listener in _fixedUpdateListeners)
			listener.FixedTick(Time.fixedDeltaTime);
	}

	public void AddListener(IFixedUpdateListener listener) => _fixedUpdateListeners.Add(listener);

	public void RemoveListener(IFixedUpdateListener listener) => _fixedUpdateListeners.Remove(listener);
}
