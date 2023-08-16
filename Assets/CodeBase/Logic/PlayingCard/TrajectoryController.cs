using CodeBase.Services.Inputs;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayingCard
{
  public class TrajectoryController : MonoBehaviour
  {
    [SerializeField] private CardThrower _cardThrower;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private float _strength = 1f;

    private IInputService _inputs;

    [Inject]
    public void Construct(IInputService inputs)
    {
      _inputs = inputs;
    }

    private void Update()
    {
      if (_inputs.FingerDown)
      {
        _trajectory.SetMiddlePositionOffset(Vector2.zero);
        _trajectory.Show();
      }

      if (_inputs.FingerDrag)
      {
        _trajectory.SetMiddlePositionOffset(_inputs.JoystickOffset * _strength);
      }
      
      if (_inputs.FingerReleased)
      {
        _trajectory.Hide();
      }
    }
  }
}