using UnityEngine;

namespace Game.Common.Entities.Items
{
    /// <summary>
    /// Объект, имитирующий предмет ракетного ранца
    /// </summary>
    public class RocketPack : Item
    {
        private int _charges;
        public RocketPack(int charges) : base("RocketPack")
        {
            _charges = charges;
        }

        public void SetCharges(int charges)
        {
            if (charges <= 0)
                throw new System.ArgumentException("Charges can not be negative");

            _charges = charges;
        }

        public override bool Use()
        {
            if (_charges <= 0)
            {
                Debug.Log("Rocket pack is out of charges");
                return false;
            }

            _charges--;
            Debug.Log("Using rocket pack");
            return true;
        }
    }
}