using System;
using EzySlice;
using UnityEngine;

namespace CodeBase.Logic.Slicing
{
  public class SliceableObject : MonoBehaviour
  {
    [SerializeField] private Material _crossSectionMaterial;

    public Action OnSliced;

    public void SliceIt(Vector3 position, Vector3 direction)
    {
      SlicedHull hull = gameObject.Slice(position, direction);

      if (hull != null)
      {
        GameObject upperHull = hull.CreateUpperHull(gameObject, _crossSectionMaterial);
        SetupSlicedObject(upperHull);
        GameObject lowerHull = hull.CreateLowerHull(gameObject, _crossSectionMaterial);
        SetupSlicedObject(lowerHull);

        OnSliced?.Invoke();
        Destroy(gameObject);
      }
    }

    private void SetupSlicedObject(GameObject slice)
    {
      Rigidbody rigidbody = slice.AddComponent<Rigidbody>();
      MeshCollider meshCollider = slice.AddComponent<MeshCollider>();
      meshCollider.convex = true;
      
      rigidbody.AddExplosionForce(80, slice.transform.position, 1);
    }
  }
}