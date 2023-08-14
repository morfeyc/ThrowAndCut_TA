using UnityEngine;

namespace CodeBase.UI.Windows
{
  [RequireComponent(typeof(Canvas))]
  public class WindowBase : MonoBehaviour
  {
    [SerializeField] private Canvas Canvas;

    private void Awake() =>
      OnAwake();

    public virtual void OnAwake()
    {
    }

    public virtual void Open() =>
      Canvas.enabled = true;

    public virtual void Close() =>
      Canvas.enabled = false;

    public virtual void Destroy() =>
      Destroy(gameObject);

    private void Reset() =>
      Canvas = GetComponent<Canvas>()
               ?? null;
  }
}