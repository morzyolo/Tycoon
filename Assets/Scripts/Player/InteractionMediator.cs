using UnityEngine;

public class InteractionMediator
{
	public void InteractDispenserWithStorage(IDispenser dispenser, IStorage storage)
	{
		if (!storage.HasFreeSpace) return;

		if (dispenser.TryDispense(out var item, storage))
			PlaceItem(dispenser, storage, item);
	}

	private void PlaceItem(IDispenser from, IStorage to, Item item)
	{
		// movement from dispenser to storage

		to.PlaceItem(item);
	}
}
