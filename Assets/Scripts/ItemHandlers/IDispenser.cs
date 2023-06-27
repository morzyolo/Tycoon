public interface IDispenser
{
	public bool TryDispense(out Item item, IStorage storage);
}
