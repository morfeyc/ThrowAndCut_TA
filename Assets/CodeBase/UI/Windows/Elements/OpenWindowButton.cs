using CodeBase.UI.Services.Window;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows.Elements
{
  [RequireComponent(typeof(Button))]
  public class OpenWindowButton : MonoBehaviour
  {
    [SerializeField] private Button Button;
    [SerializeField] private WindowId Id;

    private IWindowService _windowService;

    [Inject]
    public void Construct(IWindowService windowService)
    {
      _windowService = windowService;
    }

    private void Awake() =>
      Button.onClick.AddListener(OpenWindow);

    private void OnDestroy() =>
      Button.onClick.RemoveListener(OpenWindow);

    private void OpenWindow() =>
      _windowService.Open(Id);

    private void Reset()
    {
      if (!TryGetComponent(out Button button)) return;
      Button = button;
    }
  }
}