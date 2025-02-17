using System;
using JetBrains.Annotations;

namespace Money
{
    [UsedImplicitly]
    public class MoneyStorage
    {
        public event Action<int> OnMoneyChanged;
        
        private int _money;

        public void AddMoney(int money)
        {
            _money += money;
            OnMoneyChanged?.Invoke(_money);
        }

        public void RemoveMoney(int money)
        {
            _money -= money;
            OnMoneyChanged?.Invoke(_money);
        }
    }
}