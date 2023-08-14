using CodeBase.UI.Services.Window;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CodeBase.UI.Windows.Elements
{
  public class OpenWindowOnTap : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private WindowId Id;

    private IWindowService _windowService;

    [Inject]
    public void Construct(IWindowService windowService)
    {
      _windowService = windowService;
    }

    public void OnPointerClick(PointerEventData eventData) =>
      OpenWindow();

    private void OpenWindow() =>
      _windowService.Open(Id);
  }
}