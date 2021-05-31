namespace csharp.Items
{
    public class UpdateAgedBrie : AbstractUpdateItem
    {
        public UpdateAgedBrie(Item item)
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
            => item.Quality = item.Quality + 1 > _maxQuality ? _maxQuality : item.Quality + 1;

        public void UpdateQualityDaysLessThanZero(Item item) 
            => item.Quality = item.Quality + 1 > _maxQuality ? _maxQuality : item.Quality + 1;
    }
}
