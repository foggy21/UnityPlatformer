using System;
using Clicker.Game.Money;
using UnityEngine;

namespace Clicker.Services.Implementation
{
    public class PassiveIncomeService : Service
    {
        [Header("Additional Settings")]
        [SerializeField] protected float _incomeTime;

        protected float _currentMoneyIncome;
        protected float _currentIncomeTime;
        
        protected MoneyManager _moneyManager;
        
        public override void Upgrade()
        {
            if (!_isEnable)
            {
                EnableService();
            }
            _currentMoneyIncome = _moneyIncome;
            _moneyIncome += _upgradedIncome;
            _cost += _upgradedCost;
            base.Upgrade();
        }

        protected override void EnableService()
        {
            base.EnableService();
            _moneyManager = MoneyManager.GetInstance();
        }

        public override void Perform() {}

        protected virtual void Update()
        {
            if (_isEnable)
            {
                _currentIncomeTime += Time.deltaTime;
                if (_currentIncomeTime >= _incomeTime)
                {
                    _moneyManager.IncreaseMoney(_currentMoneyIncome);
                    _currentIncomeTime = 0;
                }
            }
        }
    }
}
