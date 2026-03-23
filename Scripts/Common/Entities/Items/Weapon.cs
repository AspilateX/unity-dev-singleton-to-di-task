using System;
using UnityEngine;

namespace Game.Common.Entities.Items
{
    /// <summary>
    /// Объект, имитирующий оружие игрока
    /// </summary>
    public class Weapon : Item
    {
        protected int Ammo;

        public Weapon(string name, int ammo) : base(name)
        {
            Ammo = ammo;
        }

        public int GetAmmo() => Ammo;

        public void SetAmmo(int ammo)
        {
            if (ammo <= 0)
                throw new ArgumentException("Ammo can not be negative");

            Ammo = ammo;
            Debug.Log($"{Name} ammo is set to {ammo}");
        }

        public override bool Use()
        {
            if (Ammo <= 0)
            {
                Debug.Log($"{Name} is out of ammo");
                return false;
            }

            Ammo--;
            Debug.Log($"Shooting from {Name}");
            return true;
        }
    }
}