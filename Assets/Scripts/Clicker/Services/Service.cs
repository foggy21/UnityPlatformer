using System;
using Clicker.Services.Manager;
using UnityEngine;
using UnityEngine.Events;

namespace Clicker.Services
{
    public abstract class Service : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] protected float _moneyIncome;
        [SerializeField] protected float _cost;
        [SerializeField] protected float _upgradedCost;
        [SerializeField] protected float _upgradedIncome;
        
        private ServiceManager _serviceManager;
        
        protected bool _isEnable;

        public UnityEvent OnUpgrade;
        
        public float MoneyIncome { get {return _moneyIncome; } }
        public float Cost { get {return _cost; } } 
        
        protected virtual void Start()
        {
            _serviceManager = ServiceManager.GetInstance();
        }

        public virtual void Upgrade()
        {
            OnUpgrade.Invoke();
        }

        protected virtual void EnableService()
        {
            _serviceManager.AddEnabledService(this);
            _isEnable = true;
        }
        public abstract void Perform();
    }
}
