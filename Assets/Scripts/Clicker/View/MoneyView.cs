using System;
using Clicker.Game.Money;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Clicker.View
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        
        private MoneyModel _moneyModel;

        private void Start()
        {
            _moneyModel = MoneyModel.GetInstance();
        }

        private void Update()
        {
            _money.text = $"{_moneyModel.Money}";
        }
    }
}
