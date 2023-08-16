using System.Collections.Generic;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Logic.PlayingCard
{
  public class Trajectory : MonoBehaviour
  {
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _vertexCount = 12;

    private Vector3 _startPoint;
    private Vector3 _middlePoint;
    private Vector3 _endPoint;
    private Vector3 _startMiddlePosition;

    private void Awake()
    {
      Hide();
    }

    private void Update()
    {
      if(!_lineRenderer.enabled)
        return;

      SmoothLine();
    }

    public void Init(Vector3 startPoint, Vector3 endPoint)
    {
      _startPoint = startPoint;
      _endPoint = endPoint;
      
      _lineRenderer.positionCount = 3;
      _lineRenderer.SetPosition(0, startPoint);

      _startMiddlePosition = VectorUtils.GetMiddlePoint(startPoint, endPoint);
      _lineRenderer.SetPosition(1, _startMiddlePosition);
      
      _lineRenderer.SetPosition(2, endPoint);
    }

    public void Show() => 
      _lineRenderer.enabled = true;

    public void Hide() => 
      _lineRenderer.enabled = false;

    public void SetMiddlePositionOffset(Vector3 offset)
    {
      _middlePoint = _startMiddlePosition + Camera.main.transform.rotation * offset;
    }

    public Vector3[] GetPositions()
    {
      var positions = new Vector3[_lineRenderer.positionCount];
      _lineRenderer.GetPositions(positions);
      return positions;
    }

    private void SmoothLine()
    {
      var pointList = new List<Vector3>();
      for (float ratio = 0; ratio <= 1; ratio += 1.0f / _vertexCount)
      {
        Vector3 tangentLineVertex1 = Vector3.Lerp(_startPoint, _middlePoint, ratio);
        Vector3 tangentLineVertex2 = Vector3.Lerp(_middlePoint, _endPoint, ratio);
        Vector3 bezierPoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
        pointList.Add(bezierPoint);
      }

      _lineRenderer.positionCount = pointList.Count;
      _lineRenderer.SetPositions(pointList.ToArray());
    }
  }
}