using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Terminal : MonoBehaviour, IInteractive
{
	[SerializeField] private ItemDispenser _itemStorage;
	[SerializeField] private Sand _sandPrefab;

	public void Interact()
	{
		if (!_itemStorage.HasFreeSpace) return;

		var item = Instantiate(_sandPrefab);
		_itemStorage.Store(item);
	}
}
