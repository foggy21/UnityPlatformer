using Clicker.Game.Money;
using Clicker.Services;
using UnityEngine;

namespace Clicker.Game.Shop
{
    public class ShopOfUpgrades : MonoBehaviour, IShoppable
    {
        private MoneyManager _moneyManager = MoneyManager.GetInstance();
        
        public void BuyService(Service service)
        {
            if (_moneyManager.MoneyModel.Money >= service.Cost)
            {
                _moneyManager.ReduceMoney(service.Cost);
                service.Upgrade();
            }
        }
    }
}
