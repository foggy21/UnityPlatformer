using UnityEngine;

namespace Clicker
{
    public class CriticalDamage : Upgrades
    {
        public bool isActive;
        public void Apply()
        {
            if (clickerManager.counterMoney >= cost)
            {
                ExchangeMoneyOnCriticalCoefficient();
                cost = (int)(cost * multiplierCost);
                UpgradeUI();
                print("Ураааааааааа!");
            }
            else
            {
                print("Деняк нет!");
            }
        }
    }
}
