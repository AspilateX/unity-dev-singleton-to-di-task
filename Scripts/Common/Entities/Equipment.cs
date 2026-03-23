using Game.Common.Entities.Items;
using System.Collections.Generic;
using System.Linq;

namespace Game.Common.Entities
{
    /// <summary>
    /// Стандартная реализация экипировки игрока
    /// </summary>
    public class Equipment : IEquipment
    {
        private List<Item> _items = new();
        public IReadOnlyCollection<Item> All => _items;

        public void Add(Item item) => _items.Add(item);

        public void Clear() => _items.Clear();

        public Item Get(string name) => _items.FirstOrDefault(i => i.Name == name);

        public bool Remove(string name) => _items.RemoveAll(i => i.Name == name) > 0;
    }
}