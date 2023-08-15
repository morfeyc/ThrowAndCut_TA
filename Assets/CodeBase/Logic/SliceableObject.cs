using EzySlice;
using UnityEngine;

namespace CodeBase.Logic
{
  public class SliceableObject : MonoBehaviour
  {
    [SerializeField] private Material _crossSectionMaterial;
    
    public void Slice(Vector3 position, Vector3 direction)
    {
      SlicedHull hull = gameObject.Slice(transform.position, transform.up);

      if (hull != null)
      {
        GameObject upperHull = hull.CreateUpperHull(gameObject, _crossSectionMaterial);
        SetupSlicedObject(upperHull);
        GameObject lowerHull = hull.CreateLowerHull(gameObject, _crossSectionMaterial);
        SetupSlicedObject(lowerHull);

        Destroy(gameObject);
      }
    }

    private void SetupSlicedObject(GameObject slice)
    {
      Rigidbody rigidbody = slice.AddComponent<Rigidbody>();
      MeshCollider meshCollider = slice.AddComponent<MeshCollider>();
      meshCollider.convex = true;
    }
  }
}