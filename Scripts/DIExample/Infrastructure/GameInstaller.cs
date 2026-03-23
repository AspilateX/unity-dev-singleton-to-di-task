using Game.Common.Entities;
using Game.Common.Entities.Items;
using Game.Common.Entities.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Infrastructure.DI
{
    /// <summary>
    /// Конфигурирует DI связи игрока
    /// </summary>
    public class GameInstaller : MonoInstaller
    {
        // Основной метод, отвечающий за конфигурацию DI контейнеров в текущем инсталлере
        public override void InstallBindings()
        {
            // Создаем связи для предметов игрока
            BindItems();
            // Создаем связи для скиллов игрока
            BindSkills();
            // Создаем связь для самого игрока
            BindPlayerInstance();
            // Создаем связь для провайдера, который будет предоставлять доступ к DI контейнеру из статических классов
            BindDIProvider();
        }

        private void BindItems()
        {
            Container
                .Bind<IEnumerable<Item>>()
                .FromInstance(new List<Item>()
                {
                    new Weapon("Rifle", 2),
                    new Parachute(),
                    new RocketPack(2)
                })
                .AsSingle();
        }

        private void BindPlayerInstance()
        {
            Container.
                Bind<IPlayer>()
                .To<Player>().
                AsSingle();
        }

        private void BindSkills()
        {
            Container.
                Bind<IEnumerable<Skill>>()
                .FromInstance(new List<Skill>()
                {
                    new Shield(TimeSpan.FromSeconds(15)),
                    new SpeedBoost(1.5f, TimeSpan.FromMinutes(1))
                })
                .AsSingle();
        }

        private void BindDIProvider()
        {
            Container
                .BindInterfacesAndSelfTo<DIProvider>()
                .AsSingle()
                .NonLazy(); // NonLazy чтобы контейнер сразу создал объект и в нем вызвался конструктор, в котором заполняются статические свойства
        }
    }
}