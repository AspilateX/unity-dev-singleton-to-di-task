using System;
using UnityEngine;

namespace Game.Common.Entities.Skills
{
    /// <summary>
    /// Объект, иммитирующий скилл, который увеличивает скорость игрока
    /// </summary>
    public class SpeedBoost : Skill
    {
        private float _boostModifier;
        private TimeSpan _duration;
        public SpeedBoost(float boostModifier, TimeSpan duration) : base("Speed Boost")
        {
            if (duration <= TimeSpan.Zero)
                throw new ArgumentException("Duration must be greater than zero");

            if (boostModifier <= 1)
                throw new ArgumentException("Boost modifier must be greater than 1");

            _boostModifier = boostModifier;
            _duration = duration;
        }
        public override bool Activate()
        {
            Debug.Log($"Activating x{_boostModifier} speed boost. Duration: {_duration.ToString(@"mm\:ss")}");
            return true;
        }
    }
}