using UnityEngine;

namespace CodeBase.Services.Inputs
{
  public interface IInputService
  {
    Vector2 JoystickOffset { get; }
    bool FingerDown { get; }
    bool FingerDrag { get; }
    bool FingerReleased { get; }
  }
}