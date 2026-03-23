using Game.Common.Entities;
using Game.Common.Entities.Items;
using Game.Common.Entities.Skills;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game.SingletonExample.Infrastructure
{
    // Реализовано через провайдер, чтобы не внедрять инфраструктурную логику
    // в сущность объектов игрока, экипировки и скиллов

    /// <summary>
    /// Объект реализующий доступ к внедряемым объектам через синглтон
    /// </summary>
    public static class SingletonProvider
    {
        private static Player _playerInstance;
        private static IEnumerable<Item> _defaultItems;
        private static IEnumerable<Skill> _defaultSkills;
        public static Player Player
        {
            get
            {
                if (_playerInstance == null)
                    _playerInstance = new Player();

                return _playerInstance;
            }
        }

        public static IEnumerable<Skill> DefaultSkills
        {
            get
            {
                if (_defaultSkills == null)
                    _defaultSkills = new List<Skill>
                    {
                        new SpeedBoost(1.5f, TimeSpan.FromMinutes(1)),
                        new Shield(TimeSpan.FromSeconds(15))
                    };

                return _defaultSkills;
            }
        }

        public static IEnumerable<Item> DefaultItems
        {
            get
            {
                if (_defaultItems == null)
                    _defaultItems = new List<Item>
                    {
                        new Weapon("Rifle", 2),
                        new Parachute(),
                        new RocketPack(2)
                    };

                return _defaultItems;
            }
        }
    }
}