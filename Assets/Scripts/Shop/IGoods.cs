namespace Shop
{
    public interface IGoods
    {
        public bool IsUnlockedByDefault();
        public CurrencyData GetSettingsForShop();
        public void Buyed(string value);
    }
}