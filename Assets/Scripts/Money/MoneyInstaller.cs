using Money;
using UnityEngine;
using Zenject;

public class MoneyInstaller : MonoInstaller
{
    [SerializeField]
    private MoneyView _moneyView;
    
    public override void InstallBindings()
    {
        Container.Bind<MoneyStorage>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().WithArguments(_moneyView);
    }
}