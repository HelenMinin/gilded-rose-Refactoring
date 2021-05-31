namespace csharp.Items
{
    public class UpdatecommonItem : AbstractUpdateItem
    { 
        public UpdatecommonItem(Item item)
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

        private void UpdateQualityDaysGreaterZero(Item item)
        {
            item.Quality = item.Quality - 1 < _minimumQuality ? _minimumQuality : item.Quality - 1;
        }

        private void UpdateQualityDaysLessThanZero(Item item)
        {
            item.Quality = item.Quality - 2 < _minimumQuality ? _minimumQuality : item.Quality - 2;
        }
    }
}
