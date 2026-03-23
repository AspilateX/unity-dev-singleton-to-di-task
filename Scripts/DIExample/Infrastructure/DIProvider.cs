using Game.Common.Entities;
using Game.Common.Entities.Items;
using Game.Common.Entities.Skills;
using Game.SingletonExample.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Infrastructure.DI
{
    /// <summary>
    /// Объект реализующий доступ к внедряемым DI объектам
    /// </summary>
    public class DIProvider
    {
        public static IEnumerable<Item> DefaultItems { get; private set; }
        public static IEnumerable<Skill> DefaultSkills { get; private set; }
        public static IPlayer Player { get; private set; }

        // Данный конструктор будет вызван при внедрении зависимостей из GameInstaller
        public DIProvider(IPlayer player, IEnumerable<Item> defaultItems, IEnumerable<Skill> defaultSkills)
        {
            Player = player;
            DefaultItems = defaultItems;
            DefaultSkills = defaultSkills;
        }
    }
}