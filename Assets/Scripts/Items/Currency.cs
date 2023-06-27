using System.Collections.Generic;

public abstract class Currency : Item
{
	public abstract KeyValuePair<CurrencyType, int> GetTypeValue();
}
