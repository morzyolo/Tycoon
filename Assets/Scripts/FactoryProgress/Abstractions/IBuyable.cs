using System.Collections.Generic;

public interface IBuyable
{
	public KeyValuePair<CurrencyType, int> GetCost();
	public void Buy();
}
