using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ClickerManager : MonoBehaviour
    {
        public TMP_Text moneyText;
        public int counterMoney;
        public int clickPower;
        public int passivePower;
        
        public int criticalCoefficient;
        public int clicksCountForCriticalDamage;

        public int currentClicksCountForCriticalDamage;

        public CriticalDamage criticalDamage;
        
        public void OnClick()
        {
            if (criticalDamage.isActive)
            {
                if (currentClicksCountForCriticalDamage >= clicksCountForCriticalDamage)
                {
                    IncreaseMoney(clickPower * criticalCoefficient);
                    currentClicksCountForCriticalDamage = 0;
                    return;
                }
                currentClicksCountForCriticalDamage++;
            }
            IncreaseMoney(clickPower);
            print($"Click {counterMoney}");
        }

        public void OnPassiveIncome()
        {
            counterMoney += passivePower;
        }

        public void ReduceMoney(int money)
        {
            counterMoney -= money;
        }
        
        public void IncreaseMoney(int money)
        {
            counterMoney += money;
        }

        public void IncreasePower(int power)
        {
            clickPower += power;
        }

        public void IncreasePassivePower(int power)
        {
            passivePower += power;
        }

        public void IncreaseCriticalCoefficient(int value)
        {
            criticalCoefficient += value;
        }

        public void Update()
        {
            moneyText.text = counterMoney.ToString();
        }
    }
}
