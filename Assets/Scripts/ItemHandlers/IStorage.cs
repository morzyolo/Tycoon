public interface IStorage
{
	public bool HasFreeSpace { get; }
	public bool TryStore(Item item);
	public void PlaceItem(Item item);
}
