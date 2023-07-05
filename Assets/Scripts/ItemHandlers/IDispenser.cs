public interface IDispenser
{
	public bool TryDispensingInStorage(out Item item, IStorage storage);
}
