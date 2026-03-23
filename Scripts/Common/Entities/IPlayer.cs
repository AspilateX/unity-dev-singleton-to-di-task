namespace Game.Common.Entities
{
    /// <summary>
    /// Интерфейс объекта, реализующего игрока
    /// </summary>
    public interface IPlayer
    {
        public IEquipment Equipment { get; }
        public ISkillTable Skills { get; }
        public int Health { get; set; }
        public int Lives { get; set; }
        public string Nickname { get; set; }
    }
}