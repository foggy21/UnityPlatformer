namespace Clicker.Game.Money
{
    public class MoneyManager
    {
        private static MoneyManager _instance;
        private MoneyModel _moneyModel = MoneyModel.GetInstance();
        
        public MoneyModel MoneyModel { get { return _moneyModel; } }
        
        private MoneyManager() {}

        public static MoneyManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoneyManager();
            }
            return _instance;
        }
        
        public void IncreaseMoney(float value)
        {
            _moneyModel.Money += value;
        }

        public void ReduceMoney(float value)
        {
            _moneyModel.Money -= value;
        }
    }
}
