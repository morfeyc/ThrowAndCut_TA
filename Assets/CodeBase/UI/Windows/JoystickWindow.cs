using Lib.Joystick_Pack;
using UnityEngine;

namespace CodeBase.UI.Windows
{
  public class JoystickWindow : WindowBase
  {
    [SerializeField] private JoyStick _joystick;

    public override void Open()
    {
      _joystick.gameObject.SetActive(true);
      _joystick.enabled = true;
      base.Open();
    }

    public override void Close()
    {
      _joystick.gameObject.SetActive(false);
      _joystick.enabled = false;
      base.Close();
    }
  }
}