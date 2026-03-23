using Game.Common.Entities.Items;
using System.Collections.Generic;

namespace Game.Common.Entities
{
    /// <summary>
    /// Интерфейс объекта, реализующего экипировку игрока
    /// </summary>
    public interface IEquipment
    {
        IReadOnlyCollection<Item> All { get; }

        public void Add(Item item);

        public Item Get(string name);

        public bool Remove(string name);
        public void Clear();
    }
}