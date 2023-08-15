using UnityEngine;

namespace CodeBase.Logic
{
  public class ObjectSlicer : MonoBehaviour
  {
    [SerializeField] private LayerMask _sliceableLayer;
    
    private void OnTriggerEnter(Collider other)
    {
      if (!IsProperLayer(other.gameObject.layer)) 
        return;
      if (!other.gameObject.TryGetComponent(out SliceableObject sliceableObject)) 
        return;
      
      sliceableObject.Slice(transform.position, transform.up);
    }

    private bool IsProperLayer(int layer)
    {
      return (_sliceableLayer.value & (1 << layer)) != 0;
    }
  }
}