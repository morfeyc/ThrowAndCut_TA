using System;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services.Inputs;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.PlayingCard
{
  public class CardThrower : MonoBehaviour
  {
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private GameObject _fakeCard;

    public bool CanThrow { get; private set; }
    public Action OnThrowStarted;
    public Action OnThrowEnded;

    private IInputService _inputs;
    private IGameFactory _gameFactory;

    [Inject]
    public void Construct(IInputService inputs, IGameFactory gameFactory)
    {
      _gameFactory = gameFactory;
      _inputs = inputs;
    }

    private void Update()
    {
      if (_inputs.FingerReleased)
      {
        Throw();
      }
    }

    public void Init(Vector3 startPoint, Vector3 endPoint)
    {
      _trajectory.Init(startPoint, endPoint);
      _fakeCard.transform.position = startPoint;
    }
    

    private async void Throw()
    {
      OnThrowStarted?.Invoke();
      _fakeCard.SetActive(false);
      
      GameObject card = await _gameFactory.CreateCard(_fakeCard.transform);
      CardMove cardMove = card.GetComponent<CardMove>();
      ObjectRotateY objectRotateY = card.GetComponent<ObjectRotateY>();
      
      Vector3[] positions = _trajectory.GetPositions();
      await cardMove.FollowTrajectory(positions);
      objectRotateY.enabled = false;
      
      _fakeCard?.SetActive(true);
      OnThrowEnded?.Invoke();
    }
  }
}