using System;
using JetBrains.Annotations;
using Zenject;

namespace Money
{
    [UsedImplicitly]
    public class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;

        public MoneyPresenter(MoneyStorage moneyStorage, MoneyView moneyView)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
        }

        public void Initialize()
        {
            _moneyView.OnButtonClicked += OnClick;
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnClick()
        {
            _moneyStorage.AddMoney(1);
        }

        private void OnMoneyChanged(int value)
        {
            _moneyView.UpdateText($"Money: {value}");
        }

        public void Dispose()
        {
            _moneyView.OnButtonClicked -= OnClick;
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}