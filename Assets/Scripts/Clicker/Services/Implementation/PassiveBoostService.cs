using Clicker.Core;
using Clicker.Game.Money;
using UnityEngine;

namespace Clicker.Services.Implementation
{
    public class PassiveBoostService : PassiveIncomeService
    {
        [Header("Boost Settings")] 
        [SerializeField] private float _afkTime;
        [SerializeField] private float _boostCoefficient;

        private float _currentAfkTime;
        private bool _isAfk;

        protected override void Start()
        {
            base.Start();
            GameManager.OnClick += DisableAfk;
        }

        protected override void Update()
        {
            if (_isEnable && !_isAfk)
            {
                Debug.Log("Try to become AFK");
                _currentAfkTime += Time.deltaTime;
                if (_currentAfkTime >= _afkTime)
                {
                    _isAfk = true;
                    _currentAfkTime = 0;
                }
            }
            
            if (_isEnable && _isAfk)
            {
                Debug.Log("I'm AFK now!");
                _currentIncomeTime += Time.deltaTime;
                if (_currentIncomeTime >= _incomeTime)
                {
                    _moneyManager.IncreaseMoney(_currentMoneyIncome * _boostCoefficient);
                    _currentIncomeTime = 0;
                }
            }
        }

        private void DisableAfk()
        {
            _isAfk = false;
            Debug.Log($"AFK = {_isAfk}");
        }
    }
}
