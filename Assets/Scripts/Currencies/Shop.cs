
using Currencies;
using UnityEngine;

public class Shop
{
    public Shop()
    {
        
    }

    public void Buy(Marshmallows product, Currency currency)
    {
        if (currency.TryChangeValue(-product.Price))
            product.ChangeValue(product.QuantityPerPrice);
    }
}