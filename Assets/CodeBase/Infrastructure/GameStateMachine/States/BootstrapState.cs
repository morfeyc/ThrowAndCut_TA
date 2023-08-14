using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Infrastructure.Services.LoadingCurtain;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class BootstrapState : IState
  {
    private readonly IGameStateMachineProvider _gameStateMachineProvider;
    private readonly IUIFactory _uiFactory;
    private readonly ILoadingCurtainService _loadingCurtain;

    public BootstrapState(IGameStateMachineProvider gameStateMachineProvider, IUIFactory uiFactory, ILoadingCurtainService loadingCurtain)
    {
      _gameStateMachineProvider = gameStateMachineProvider;
      _uiFactory = uiFactory;
      _loadingCurtain = loadingCurtain;
    }
    
    public async void Enter()
    {
      await _uiFactory.CreateUIRoot();
      await _loadingCurtain.Initialize();
      
      _gameStateMachineProvider.Value.Enter<LoadProgressState>();
    }

    public void Exit()
    {
    }
  }
}