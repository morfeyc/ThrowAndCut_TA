using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
  public interface IGameFactory
  {
    UniTask<T> InstantiateDIObject<T>(string assetKey) where T : MonoBehaviour;
    UniTask<T> InstantiateDIObjectRegistered<T>(string assetKey) where T : MonoBehaviour;
    void Cleanup();
  }
}