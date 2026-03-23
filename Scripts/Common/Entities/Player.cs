using System;

namespace Game.Common.Entities
{
    /// <summary>
    /// Стандартная реализация игрока
    /// </summary>
    public class Player : IPlayer
    {
        private readonly IEquipment _equipment = new Equipment();
        private readonly ISkillTable _skills = new SkillTable();
        private int _health;
        private int _lives;
        private string _nickname;
        public IEquipment Equipment => _equipment;
        public int Health { get => _health; set => _health = Math.Max(0, value); }
        public int Lives { get => _lives; set => _lives = Math.Max(0, value); }
        public string Nickname { get => _nickname; set => _nickname = value; }
        public ISkillTable Skills => _skills;
    }
}