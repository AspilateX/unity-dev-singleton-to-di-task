using System;
using UnityEngine;

namespace Game.Common.Entities.Skills
{
    /// <summary>
    /// Объект, иммитирующий скилл, который создает щит, поглощающий урон игрока
    /// </summary>
    public class Shield : Skill
    {
        private TimeSpan _duration;
        public Shield(TimeSpan duration) : base("Shield")
        {
            if (duration <= TimeSpan.Zero)
                throw new ArgumentException("Duration must be greater than zero");

            _duration = duration;
        }
        public override bool Activate()
        {
            Debug.Log($"Activating shield. Duration: {_duration.ToString(@"mm\:ss")}");
            return true;
        }
    }
}