using UnityEngine;

namespace CodeBase.Utils
{
  public static class VectorUtils
  {
    public static Vector3 GetMiddlePoint(Vector3 vectorA, Vector3 vectorB) => 
      (vectorA + vectorB) / 2;
  }
}