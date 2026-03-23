namespace Game.Common.Entities.Items
{
    /// <summary>
    /// Класс, представляющий предмет экипировки игрока
    /// </summary>
    public abstract class Item
    {
        public readonly string Name;
        public Item(string name) 
        {
            Name = name;
        }
        /// <summary>
        /// Метод, отвечающий за использование предмета.
        /// </summary>
        /// <returns>true, если использование прошло успешно, иначе false.</returns>
        public abstract bool Use();
    }
}