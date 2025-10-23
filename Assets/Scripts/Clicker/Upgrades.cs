using TMPro;
using UnityEngine;

namespace Clicker
{
    public class Upgrades : MonoBehaviour
    {
        public ClickerManager clickerManager;
        public int cost;
        public int incomePower;
        public float multiplierCost;
        public TMP_Text costText;
        public TMP_Text bonusPowerText;
        
        public virtual void Start()
        {
            costText.text = $"Cost: {cost.ToString()}";
            bonusPowerText.text = $"Bonus: {incomePower.ToString()}";
            print("Старый метод Start в классе Upgrades.");
        }

        public void ExchangeMoneyOnPower()
        {
            clickerManager.ReduceMoney(cost);
            clickerManager.IncreasePower(incomePower);
        }

        public void ExchangeMoneyOnCriticalCoefficient()
        {
            clickerManager.ReduceMoney(cost);
            clickerManager.IncreaseCriticalCoefficient(incomePower);
        }

        public void ExchangeMoneyOnPassivePower()
        {
            clickerManager.ReduceMoney(cost);
            clickerManager.IncreasePassivePower(incomePower);
        }

        public void UpgradeUI()
        {
            costText.text = $"Cost: {cost.ToString()}";
            bonusPowerText.text = $"Bonus: {incomePower.ToString()}";
        }
    }
}
