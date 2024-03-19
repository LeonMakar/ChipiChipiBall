using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private PaddleMooving _paddleMooving;
    [SerializeField] private MediaMaterialController _mediaMaterialController;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _X3BonusPrefab;
    [SerializeField] private GameToken _calncelationToken;
    [SerializeField] private GameStateMachine _gameStateMachine;
    [SerializeField] private GameFinishSelector _gameFinishSelector;

    public void Initialize()
    {

        InitializeAllFactory();
        InitializeAllPool();

        GlobalVariables.MEDIA = _mediaMaterialController;
    }

    public override void InstallBindings()
    {
        BindSceneInstalletInterfaces();
        BindPaddleMoovingScript();
        BindMediaController();
        BindSimpleBallFactory();
        BindBallsController();
        BindCustomeBallPool();
        BindBonusX3Factory();
        BindX3Pool();
        BindGameToken();
        BindGameStateMachine();
        BindEventBus();
        BindGameFinishSelector();
    }

    private void BindGameFinishSelector()
    {
        Container
            .Bind<GameFinishSelector>()
            .FromInstance(_gameFinishSelector)
            .AsSingle();
    }

    private void BindEventBus()
    {
        Container.Bind<EventBus>()
            .AsSingle()
            .NonLazy();
    }

    private void BindGameStateMachine()
    {
        Container
                     .Bind<GameStateMachine>()
                     .FromInstance(_gameStateMachine)
                     .AsSingle()
                     .NonLazy();
    }

    private void BindGameToken()
    {
        Container
            .Bind<GameToken>()
            .FromInstance(_calncelationToken)
            .AsSingle()
            .NonLazy();
    }
    private void BindX3Pool()
    {
        Container
            .Bind<CustomePool<X3Bonus>>()
            .AsSingle()
            .NonLazy();
    }

    private void BindBonusX3Factory()
    {
        Container
            .Bind<BonusFactory<X3Bonus>>()
            .AsSingle()
            .NonLazy();
    }

    private void BindCustomeBallPool()
    {
        Container
                    .Bind<CustomePool<SimpleBall>>()
                    .AsSingle();
    }

    private void BindBallsController()
    {
        Container
                    .Bind<BallsController>()
                    .AsSingle()
                    .NonLazy();
    }
    private void BindSimpleBallFactory()
    {
        Container.
            Bind<BallFactory>()
            .AsSingle()
            .NonLazy();

    }
    private void BindMediaController()
    {
        Container
                    .Bind<MediaMaterialController>()
                    .FromInstance(_mediaMaterialController)
                    .NonLazy();
    }

    private void BindSceneInstalletInterfaces()
    {
        Container
             .BindInterfacesTo<SceneInstaller>()
             .FromInstance(this)
             .AsSingle()
             .NonLazy();
    }

    private void BindPaddleMoovingScript()
    {
        Container
           .Bind<PaddleMooving>()
           .FromInstance(_paddleMooving)
           .AsSingle();
    }
    private void InitializeAllPool()
    {
        Container.Resolve<CustomePool<SimpleBall>>().InitializePool(Container.Resolve<BallFactory>(), 500);
        Container.Resolve<CustomePool<X3Bonus>>().InitializePool(Container.Resolve<BonusFactory<X3Bonus>>(), 20);
    }

    private void InitializeAllFactory()
    {
        Container.Resolve<BallFactory>().LoadFactoryResources(_ballPrefab);
        Container.Resolve<BonusFactory<X3Bonus>>().LoadFactoryResources(_X3BonusPrefab);

    }
}
