using CodeBase.Services.Progress;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Slicing
{
  public class ObjectSlicer : MonoBehaviour
  {
    [SerializeField] private LayerMask _sliceableLayer;
    private IProgressService _progressService;

    [Inject]
    public void Construct(IProgressService progressService)
    {
      _progressService = progressService;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if (!IsProperLayer(other.gameObject.layer)) 
        return;
      if (!other.gameObject.TryGetComponent(out SliceableObject sliceableObject)) 
        return;
      
      sliceableObject.SliceIt(transform.position, transform.up);
      _progressService.Progress.LevelTask.FruitSliced();
    }

    private bool IsProperLayer(int layer)
    {
      return (_sliceableLayer.value & (1 << layer)) != 0;
    }
  }
}