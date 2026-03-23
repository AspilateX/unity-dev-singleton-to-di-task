namespace Game.Common.Entities.Skills
{
    /// <summary>
    /// Класс, представляющий скилл игрока
    /// </summary>
    public abstract class Skill
    {
        public readonly string Name;

        protected Skill(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Активирует текущий скилл
        /// </summary>
        /// <returns>true если скилл был активирован успешно, иначе false</returns>
        public abstract bool Activate();
    }
}