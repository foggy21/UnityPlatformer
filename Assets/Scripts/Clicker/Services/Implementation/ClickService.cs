using Clicker.Game.Money;
using UnityEngine;

namespace Clicker.Services.Implementation
{
    public class ClickService : Service
    {
        private MoneyManager _moneyManager;

        private float _multiplyCoefficient;
        private bool _isMultiplyClick;
        
        protected override void Start()
        {
            base.Start();
            EnableService();
        }

        public override void Upgrade()
        {
            if (!_isEnable)
            {
                EnableService();
                return;
            }
            _moneyIncome += _upgradedIncome;
            _cost += _upgradedCost;
            base.Upgrade();
        }

        protected override void EnableService()
        {
            base.EnableService();
            MultiplyClickService.OnMultiply += SetMultiplyClick;
            _moneyManager = MoneyManager.GetInstance();
        }

        public override void Perform()
        {
            if (_isMultiplyClick)
            {
                _moneyManager.IncreaseMoney(_moneyIncome * _multiplyCoefficient);
                _isMultiplyClick = false;
                return;
            }
            _moneyManager.IncreaseMoney(_moneyIncome);
        }

        private void SetMultiplyClick(float coefficient)
        {
            _multiplyCoefficient = coefficient;
            _isMultiplyClick = true;
        }
    }
}
