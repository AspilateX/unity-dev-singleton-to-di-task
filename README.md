## Точка входа

Примеры использования инфраструктуры находятся в `Common/Behaviours/Main.cs`

## Навигация

- `Common` - общая доменная логика и базовые сущности.
- `DIExample` - реализация DI через Zenject.
- `SingletonExample` - реализация через Singleton.

## Структура

```text
Scripts/
├─ Common/
│  ├─ Behaviours/
│  │  └─ Main.cs
│  └─ Entities/
│     ├─ Items/         (Item, Weapon, Parachute, RocketPack)
│     ├─ Skills/        (Skill, Shield, SpeedBoost)
│     ├─ Player.cs
│     ├─ Equipment.cs
│     └─ SkillTable.cs
├─ DIExample/
│  └─ Infrastructure/   (GameInstaller.cs, DIProvider.cs)
└─ SingletonExample/
   └─ Infrastructure/   (SingletonProvider.cs)
```

## Проверка в Unity

Проект рассчитан на использование в Unity с установленным Zenject
Тестировался в Unity 2022.3.62f3 (LTS)

Для проверки в Unity нужно:
- Установить Zenject согласно официальному гайду;
- В нужной сцене создать `SceneContext`, к нему добавить компонент `GameInstaller`, перенести его в список `Mono Installers`
- В создать объект с компонентом класса `Main.cs`
- Для теста инфраструктуры любым способом вызывать публичные методы из `Main` компонента в режиме игры

Или установить приложенный .unitypackage
В нем создана сцена `Boot`, в которой все реализовано и предоставлен небольшой UI интерфейс для проверки