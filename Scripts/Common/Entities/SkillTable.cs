using Game.Common.Entities.Skills;
using System.Collections.Generic;

namespace Game.Common.Entities
{
    /// <summary>
    /// Стандартная реализация таблицы скиллов игрока
    /// </summary>
    public class SkillTable : ISkillTable
    {
        private readonly List<Skill> _skills = new();
        public IReadOnlyCollection<Skill> All => _skills;

        public void Clear() => _skills.Clear();

        public bool Forget(string name) => _skills.RemoveAll(i => i.Name == name) > 0;

        public bool Learn(Skill skill)
        {
            if (skill == null)
                return false;

            _skills.Add(skill);
            return true;
        }
    }
}