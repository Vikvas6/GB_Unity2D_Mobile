using System.Collections.Generic;


namespace Game.Item
{
    public interface IItem
    {
        int Id { get; }
        ItemInfo Info { get; }
    }

    public struct ItemInfo
    {
        public string Title { get; set; }
    }
}

