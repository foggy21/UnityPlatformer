using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ClickerManager : MonoBehaviour
    {
        public TMP_Text moneyText;
        public int counterMoney;
        public int clickPower;
        
        public void OnClick()
        {
            counterMoney += clickPower;
            print($"Click {counterMoney}");
        }

        public void ReduceMoney(int money)
        {
            counterMoney -= money;
        }

        public void IncreasePower(int power)
        {
            clickPower += power;
        }

        public void Update()
        {
            moneyText.text = counterMoney.ToString();
        }
    }
}
