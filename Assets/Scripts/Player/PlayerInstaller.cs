using Components;
using Zenject;

namespace Player
{
    public class PlayerInstaller : Installer<MoveComponent, PlayerInstaller>
    {
        [Inject]
        private MoveComponent _moveComponent;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .WithArguments(_moveComponent)
                .NonLazy();
        }
    }
}