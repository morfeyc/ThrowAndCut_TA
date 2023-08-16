using CodeBase.Services.Inputs;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayingCard
{
  public class FakeCardInclination : MonoBehaviour
  {
    [SerializeField] private Transform _transform;
    [SerializeField] private float _strength = 1;
    
    private IInputService _inputs;

    [Inject]
    public void Construct(IInputService inputs)
    {
      _inputs = inputs;
    }

    private void Update()
    {
      float offsetX = _inputs.JoystickOffset.x * _strength;
      _transform.rotation = Quaternion.Euler(0, offsetX, -offsetX);
    }
  }
}