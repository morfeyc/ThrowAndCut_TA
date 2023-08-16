using Lib.Joystick_Pack;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Inputs
{
  public class InputService : IInputService, ITickable
  {
    public Vector2 JoystickOffset { get; private set; }
    public bool FingerDown { get; private set; }
    public bool FingerDrag { get; private set; }
    public bool FingerReleased { get; private set; }

    public void Tick()
    {
      JoystickOffset = JoyStick.Active ? JoyStick.Move : Vector2.zero;

      FingerDown = JoyStick.StartDragging;
      FingerDrag = JoyStick.Active;
      FingerReleased = JoyStick.EndDragging;
    }
  }
}