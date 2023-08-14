using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Services.SceneLoader;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly IGameStateMachineProvider _stateMachineProvider;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly IGameFactory _gameFactory;

    public LoadLevelState(IGameStateMachineProvider stateMachineProvider,
      ISceneLoaderService sceneLoader,
      IGameFactory gameFactory)
    {
      _stateMachineProvider = stateMachineProvider;
      _sceneLoader = sceneLoader;
      _gameFactory = gameFactory;
    }

    public void Enter(string payload)
    {
      _gameFactory.Cleanup();
      
      _sceneLoader.Load(payload, onLoaded: OnLoaded);
    }

    public void Exit()
    {
    }

    private void OnLoaded()
    {
      _stateMachineProvider.Value.Enter<GameLoopState>();
    }
  }
}