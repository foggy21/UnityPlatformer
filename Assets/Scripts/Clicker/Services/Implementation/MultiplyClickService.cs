using Clicker.Core;
using UnityEngine;

namespace Clicker.Services.Implementation
{
    public class MultiplyClickService : Service
    {
        [Header("Multiply Settings")] 
        [SerializeField] private float _multiplyCoefficient;
        [SerializeField] private int _clicksForMultiply;
        
        private int _currentClicks;
        
        public delegate void MultiplyHandler(float coefficient);
        public static event MultiplyHandler OnMultiply;

        public override void Upgrade()
        {
            if (!_isEnable)
            {
                EnableService();
                return;
            }
            _multiplyCoefficient += _upgradedIncome;
            _cost += _upgradedCost;
            base.Upgrade();
        }

        public override void Perform()
        {
            _currentClicks += 1;
            if (_currentClicks >= _clicksForMultiply)
            {
                OnMultiply?.Invoke(_multiplyCoefficient);
                _currentClicks = 0;
            }
        }
    }
}
