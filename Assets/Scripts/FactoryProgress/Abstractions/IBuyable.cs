using System.Collections.Generic;

public interface IBuyable
{
	public KeyValuePair<CurrencyType, uint> GetCost();
	public void Buy();
}
