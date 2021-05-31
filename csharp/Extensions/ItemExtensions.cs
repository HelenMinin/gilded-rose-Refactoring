using csharp.Const;
using csharp.Items;

namespace csharp.Extensions
{
    public static class ItemExtensions
    {
        public static void UpdateItem(this Item item)
        {
            if (item.Name.Equals(TypeItem.Sulfuras))
                return;

            switch (item.Name)
            {
                case TypeItem.AgedBrie:
                    new UpdateAgedBrie(item);
                    break;
                case TypeItem.Backstage:
                    new UpdateBackstage(item);
                    break;
                case TypeItem.Conjured:
                    new UpdateConjured(item);
                    break;
                default:
                    new UpdatecommonItem(item);
                    break;
            }
        }
    }
}
