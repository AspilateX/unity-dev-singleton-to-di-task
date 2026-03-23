using Game.Common.Entities;
using Game.Common.Entities.Items;
using Game.Common.Entities.Skills;
using Game.SingletonExample.Infrastructure;
using Infrastructure.DI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SingletonExample.Behaviours
{
    /// <summary>
    /// Демонстрирует работу с игроком, созданным через DI или Singleton инфраструктуру, а также с его экипировкой и скиллами
    /// </summary>
    public class Main : MonoBehaviour
	{
        private IEnumerable<Item> _defaultItems;
        private IEnumerable<Skill> _defaultSkills;
        private IPlayer _player;

        /// <summary>
        /// Демонстрирует работу с ХП игрока
        /// </summary>
        /// <param name="amount">Количество добавляемого ХП</param>
        public void AddPlayerHealth(int amount)
        {
            if (_player == null)
            {
                Debug.LogError("Player is not initialized");
                return;
            }

            _player.Health += amount;
            Debug.Log($"Player health is {_player.Health}");
        }

        /// <summary>
        /// Демонстрирует работу с параметром конкретног предмета игрока
        /// </summary>
        /// <param name="amount">Количество патрон</param>
        public void AddWeaponAmmo(int amount)
        {
            if (_player == null)
            {
                Debug.LogError("Player is not initialized");
                return;
            }

            Weapon weapon = _player.Equipment.Get("Rifle") as Weapon;

            if (weapon == null)
            {
                Debug.LogError("Rifle not found in player equipment");
                return;
            }

            int currentAmmo = weapon.GetAmmo();
            weapon.SetAmmo(currentAmmo + amount);
        }

        /// <summary>
        /// Переключает текущую инфраструктуру между DI и Singleton
        /// </summary>
        /// <param name="useDI">Если true, будет использоваться DI, иначе Singleton</param>
        public void SwitchInfrastructure(bool useDI)
        {
            // Получаем экземпляр игрока, стандартных предметов и скиллов в зависимости от выбранной инфраструктуры

            if (useDI)
            {
                _player = DIProvider.Player;
                _defaultItems = DIProvider.DefaultItems;
                _defaultSkills = DIProvider.DefaultSkills;
            }
            else
            {
                _player = SingletonProvider.Player;
                _defaultItems = SingletonProvider.DefaultItems;
                _defaultSkills = SingletonProvider.DefaultSkills;
            }

            string infrastructureName = useDI ? "DI" : "Singleton";
            Debug.Log($"Switched to {infrastructureName} player instance");
        }

        /// <summary>
        /// Демонстрирует использование всех предметов игрока
        /// </summary>
        public void UseItems()
        {
            foreach (var item in _player.Equipment.All)
                item.Use();
        }

        /// <summary>
        /// Демонстрирует использование всех предметов скиллов игрока
        /// </summary>
        public void UseSkills()
        {
            foreach (var skill in _player.Skills.All)
                skill.Activate();
        }

        private void Awake()
        {
            // Инициализируем DI игрока и его начальные данные
            SwitchInfrastructure(true);
            SetupPlayer();

            // Инициализируем синглтон игрока и его начальные данные
            SwitchInfrastructure(false);
            SetupPlayer();
        }

        /// <summary>
        /// Вставляет в игрока начальные данные
        /// </summary>
        private void SetupPlayer()
        {
            // Задаем игроку начальные данные
            _player.Health = 100;
            _player.Lives = 3;
            _player.Nickname = "player";

            // Добавляем стандартные предметы в инвентарь игрока

            foreach (var item in _defaultItems)
                _player.Equipment.Add(item);

            // Добавляем стандартные скиллы игроку

            foreach (var skill in _defaultSkills)
                _player.Skills.Learn(skill);
        }
    }
}