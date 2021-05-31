using csharp.Const;


namespace csharp.Items
{

    public abstract class AbstractUpdateItem
    {
        protected const int _maxQuality = 50;
        protected const int _minimumQuality = 0;

        protected void UpdateSellIn(Item item)
        {
            if (item.Name.Equals(TypeItem.Sulfuras))
                return;

            item.SellIn--;
        }

        protected bool IsDaysLessThanZero(int sellIn) => sellIn <= 0;
    }
}
