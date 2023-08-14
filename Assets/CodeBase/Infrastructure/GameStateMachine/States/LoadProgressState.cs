using CodeBase.Data;
using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class LoadProgressState : IState
  {
    private readonly IGameStateMachineProvider _stateMachineProvider;
    private readonly IProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(IGameStateMachineProvider stateMachineProvider, IProgressService progressService, ISaveLoadService saveLoadService)
    {
      _stateMachineProvider = stateMachineProvider;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }
    
    public void Enter()
    {
      LoadProgressOrInitNew();
      
      _stateMachineProvider.Value.Enter<LoadLevelState, string>("Main");
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew()
    {
      _progressService.Progress =
        _saveLoadService.LoadProgress()
        ?? NewProgress();
    }

    private PlayerProgress NewProgress() => 
      new();
  }
}