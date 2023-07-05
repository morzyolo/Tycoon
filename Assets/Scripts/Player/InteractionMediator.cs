using UnityEngine;

public class InteractionMediator
{
	public void InteractDispenserWithStorage(IDispenser dispenser, IStorage storage)
	{
		if (!storage.HasFreeSpace) return;

		if (dispenser.TryDispensingInStorage(out var item, storage))
			MoveItem(dispenser, storage, item);
	}

	private void MoveItem(IDispenser from, IStorage to, Item item)
	{
		// movement from dispenser to storage

		to.PlaceItem(item);
	}
}
