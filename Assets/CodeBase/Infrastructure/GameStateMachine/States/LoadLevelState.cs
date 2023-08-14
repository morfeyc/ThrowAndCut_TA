using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Services.Progress;
using CodeBase.Services.SceneLoader;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class LoadLevelState : IPayloadedState<int>
  {
    private readonly IGameStateMachineProvider _stateMachineProvider;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly IProgressService _progressService;
    private readonly IWindowService _windowService;

    public LoadLevelState(IGameStateMachineProvider stateMachineProvider,
      ISceneLoaderService sceneLoader,
      IGameFactory gameFactory,
      IStaticDataService staticDataService,
      IProgressService progressService,
      IWindowService windowService)
    {
      _stateMachineProvider = stateMachineProvider;
      _sceneLoader = sceneLoader;
      _gameFactory = gameFactory;
      _staticDataService = staticDataService;
      _progressService = progressService;
      _windowService = windowService;
    }

    public void Enter(int payload)
    {
      _gameFactory.Cleanup();
      _windowService.CloseAll();

      _sceneLoader.Load(CurrentLevelName(), onLoaded: OnLoaded);
    }

    public void Exit()
    {
    }

    private void OnLoaded()
    {
      _stateMachineProvider.Value.Enter<GameLoopState>();
      _windowService.Open(WindowId.Joystick);
    }

    private string CurrentLevelName()
    {
      string sceneName = _staticDataService
        .ForLevel(_progressService.Progress.CurrentLevelId + 1)
        .LevelKey;
      return sceneName;
    }
  }
}