public interface IDispenser
{
	public bool TryDispense(out CarriableItem carriableItem);
	public bool TryRefill(CarriableItem carriableItem);
}
