using Game.Common.Entities.Skills;
using System.Collections.Generic;

namespace Game.Common.Entities
{
    /// <summary>
    /// Интерфейс объекта, реализующего таблицу скиллов игрока
    /// </summary>
    public interface ISkillTable
    {
        IReadOnlyCollection<Skill> All { get; }

        bool Forget(string skillName);

        bool Learn(Skill skill);

        void Clear();
    }
}