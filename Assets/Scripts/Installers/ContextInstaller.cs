using Zenject;

public class ContextInstaller : MonoInstaller<ContextInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<GamePauseEventDispatcher>().AsSingle();
        Container.Bind<ObjectPickupEventDispatcher>().AsSingle();
        Container.Bind<EnemyKilledEventDispatcher>().AsSingle();
    }
}
