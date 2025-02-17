using JetBrains.Annotations;
using Zenject;

namespace Input
{
    [UsedImplicitly]
    public class InputInstaller : Installer<Joystick, InputInstaller>
    {
        [Inject]
        private Joystick _joystick;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<InputAdapter>()
                .AsSingle()
                .WithArguments(_joystick)
                .NonLazy();
        }
    }
}