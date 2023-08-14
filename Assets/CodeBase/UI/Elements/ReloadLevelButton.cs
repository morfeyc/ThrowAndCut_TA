using CodeBase.Infrastructure.GameStateMachine.Provider;
using CodeBase.Infrastructure.GameStateMachine.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
  public class ReloadLevelButton : MonoBehaviour
  {
    [SerializeField] private Button Button;

    private IGameStateMachineProvider _stateMachineProvider;

    [Inject]
    public void Construct(IGameStateMachineProvider stateMachineProvider)
    {
      _stateMachineProvider = stateMachineProvider;
    }

    private void Awake() =>
      Button.onClick.AddListener(ReloadLevel);

    private void OnDestroy() =>
      Button.onClick.RemoveListener(ReloadLevel);

    private void ReloadLevel() =>
      _stateMachineProvider.Value.Enter<LoadLevelState, string>(CurrentSceneName());

    private static string CurrentSceneName() =>
      SceneManager.GetActiveScene().name;

    private void Reset() => 
      Button = GetComponent<Button>() 
               ?? null;
  }
}