using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Infrastructure.GameStateMachine.States;
using CodeBase.Services.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
  public class LoadCurrentLevelButton : MonoBehaviour
  {
    [SerializeField] private Button Button;

    private IGameStateMachineProvider _stateMachineProvider;
    private IProgressService _progressService;

    [Inject]
    public void Construct(IGameStateMachineProvider stateMachineProvider, IProgressService progressService)
    {
      _progressService = progressService;
      _stateMachineProvider = stateMachineProvider;
    }

    private void Awake() =>
      Button.onClick.AddListener(ReloadLevel);

    private void OnDestroy() =>
      Button.onClick.RemoveAllListeners();

    private void ReloadLevel() =>
      _stateMachineProvider.Value
        .Enter<LoadLevelState, int>(_progressService.Progress.CurrentLevelId);

    private void Reset() => 
      Button = GetComponent<Button>() 
               ?? null;
  }
}