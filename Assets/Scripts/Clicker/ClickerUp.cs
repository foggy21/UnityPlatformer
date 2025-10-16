using System;
using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ClickerUp : MonoBehaviour
    {
        public int cost;
        public int bonusPower;
        public float multiplierCost;
        public ClickerManager clickerManager;

        public TMP_Text costText;
        public TMP_Text bonusPowerText;

        private void Start()
        {
            clickerManager = GetComponent<ClickerManager>();
            
            costText.text = $"Cost: {cost.ToString()}";
            bonusPowerText.text = $"Bonus: {bonusPower.ToString()}";
        }

        public void Apply()
        {
            if (clickerManager.counterMoney >= cost)
            {
                clickerManager.ReduceMoney(cost);
                clickerManager.IncreasePower(bonusPower);
                cost = (int)(cost * multiplierCost);
                costText.text = $"Cost: {cost.ToString()}";
                bonusPowerText.text = $"Bonus: {bonusPower.ToString()}";
                print("Ураааааааааа!");
            }
            else
            {
                print("Деняк нет!");
            }
        }
    }
}
