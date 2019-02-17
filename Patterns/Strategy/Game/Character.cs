using System;

namespace Strategy.Game
{
    public abstract class Character
    {
        private IWeaponBehavior _weaponBehavior;

        public void SetWeapon(IWeaponBehavior weaponBehavior)
        {
            _weaponBehavior = weaponBehavior;
        }

        public virtual void Fight()
        {
            if (_weaponBehavior == null)
            {
                Console.WriteLine("I don't have a weapon");
                return;
            }

            _weaponBehavior?.UseWeapon();
        }
    }

    public class Queen : Character
    {

    }

    public class King : Character
    {

    }

    public class Troll : Character
    {

    }

    public class Knight : Character
    {

    }

    public interface IWeaponBehavior
    {
        void UseWeapon();
    }

    public class Knife : IWeaponBehavior
    {
        /// <summary>
        /// Удар ножом
        /// </summary>
        public void UseWeapon()
        {
            throw new NotImplementedException();
        }
    }

    public class BowAndArrow : IWeaponBehavior
    {
        /// <summary>
        /// Выстрел из лука
        /// </summary>
        public void UseWeapon()
        {
            throw new NotImplementedException();
        }
    }


    public class Axe : IWeaponBehavior
    {
        /// <summary>
        /// Удар топором
        /// </summary>
        public void UseWeapon()
        {
            throw new NotImplementedException();
        }
    }

    public class Sword : IWeaponBehavior
    {
        /// <summary>
        /// Удар мечом
        /// </summary>
        public void UseWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
