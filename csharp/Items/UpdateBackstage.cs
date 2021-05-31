namespace csharp.Items
{
    public class UpdateBackstage : AbstractUpdateItem
    {
        public UpdateBackstage(Item item)
        {
            if (IsDaysLessThanZero(item.SellIn))
            {
                UpdateQualityDaysLessThanZero(item);
                UpdateSellIn(item);
                return;
            }

            UpdateQualityDaysGreaterZero(item);
            UpdateSellIn(item);
        }
        public void UpdateQualityDaysGreaterZero(Item item)
        {
            if (item.Quality >= 50)
                return;

            var quality = item.SellIn < 0 ? 0 : item.SellIn <= 5 ? item.Quality + 3 : item.SellIn <= 10 ? item.Quality + 2 : item.Quality + 1;

            item.Quality = quality > _maxQuality ? _maxQuality : quality;
        }

        public void UpdateQualityDaysLessThanZero(Item item)
        {
            item.Quality = 0;
        }
    }
}
