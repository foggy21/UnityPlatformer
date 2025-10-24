namespace Clicker.Game.Money
{
    public class MoneyModel
    {
        private static MoneyModel _instance;
        private float _money;
        public float Money { get; set; }
        private MoneyModel() {}

        public static MoneyModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoneyModel();
            }
            return _instance;
        }
    }
}
