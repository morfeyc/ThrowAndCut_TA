using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI.Windows.Elements
{
  public class CloseWindowOnTap : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private WindowBase Window;

    public void OnPointerClick(PointerEventData eventData) =>
      CloseWindow();

    private void CloseWindow() =>
      Window.Close();
  }
}