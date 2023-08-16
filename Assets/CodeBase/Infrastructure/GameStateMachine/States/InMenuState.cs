using CodeBase.Services.SceneLoader;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;

namespace CodeBase.Infrastructure.GameStateMachine.States
{
  public class InMenuState : IState
  {
    private readonly ISceneLoaderService _sceneLoader;
    private readonly IWindowService _windowService;

    public InMenuState(ISceneLoaderService sceneLoader, IWindowService windowService)
    {
      _sceneLoader = sceneLoader;
      _windowService = windowService;
    }
    
    public void Enter()
    {
      _sceneLoader.Load(SceneNames.MenuSceneName, onLoaded: OnLoaded);
    }

    public void Exit()
    {
    }
    
    private void OnLoaded()
    {
      _windowService.Open(WindowId.MainMenu);
    }
  }
}