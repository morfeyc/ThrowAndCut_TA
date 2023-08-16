using System;
using CodeBase.Services.Progress;
using CodeBase.Services.SaveLoad;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class GameLoopState : ITickableState
  {
    private const float DelayForEndScreen = 1.5f;
    
    private readonly IProgressService _progressService;
    private readonly IWindowService _windowService;
    private ISaveLoadService _saveLoadService;

    public GameLoopState(IProgressService progressService, IWindowService windowService, ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
      _windowService = windowService;
      _progressService = progressService;
    }

    public void Enter()
    {
      _progressService.Progress.LevelTask.OnCompleted += OnCompleted;
    }

    public void Tick()
    {
    }

    public void Exit()
    {
      _progressService.Progress.LevelTask.OnCompleted -= OnCompleted;
    }

    private async void OnCompleted()
    {
      UpdateAndSaveProgress();

      _windowService.CloseAll();
      await UniTask.Delay(TimeSpan.FromSeconds(DelayForEndScreen));
      _windowService.Open(WindowId.LevelEnd);
    }

    private void UpdateAndSaveProgress()
    {
      _progressService.Progress.CurrentLevelId++;
      _saveLoadService.SaveProgress();
    }
  }
}