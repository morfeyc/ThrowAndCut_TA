using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Logic
{
  public class Trajectory : MonoBehaviour
  {
    [SerializeField] private LineRenderer _lineRenderer;

    private Vector3 _startMiddlePosition;

    private void Awake()
    {
      Hide();
    }

    public void Show() => 
      _lineRenderer.enabled = true;

    public void Hide() => 
      _lineRenderer.enabled = false;

    public void SetMiddlePositionOffset(Vector3 offset)
    {
      _lineRenderer.SetPosition(1, _startMiddlePosition + offset);
    }

    public void Init(Vector3 startPoint, Vector3 endPoint)
    {
      _lineRenderer.positionCount = 3;
      _lineRenderer.SetPosition(0, startPoint);

      _startMiddlePosition = VectorUtils.GetMiddlePoint(startPoint, endPoint);
      _lineRenderer.SetPosition(1, _startMiddlePosition);
      
      _lineRenderer.SetPosition(2, endPoint);
    }
  }
}