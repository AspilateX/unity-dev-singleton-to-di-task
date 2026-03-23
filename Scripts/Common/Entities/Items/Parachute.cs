using UnityEngine;

namespace Game.Common.Entities.Items
{
    /// <summary>
    /// Объект, имитирующий предмет парашюта
    /// </summary>
    public class Parachute : Item
    {
        public Parachute() : base("Parachute") { }

        public override bool Use()
        {
            Debug.Log("Using parachute");
            return true;
        }
    }
}