using UnityEngine;

namespace Clicker
{
    public class PassiveIncomeUp : Upgrades
    {
        public float incomeTime;
        public float incomeCurrentTime;
        public bool isActive;

        private void Update()
        {
            if (isActive)
            {
                incomeCurrentTime += Time.deltaTime;
                if (incomeCurrentTime >= incomeTime)
                {
                    clickerManager.OnPassiveIncome();
                    print("Таймер!");
                    incomeCurrentTime = 0;
                }    
            }
        }
        
        public void Apply()
        {
            if (clickerManager.counterMoney >= cost)
            {
                isActive = true;
                ExchangeMoneyOnPassivePower();
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
