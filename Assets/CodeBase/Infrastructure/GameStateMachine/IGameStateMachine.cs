﻿using CodeBase.Infrastructure.GameStateMachine.States;

namespace CodeBase.Infrastructure.GameStateMachine
{
  public interface IGameStateMachine
  {
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
  }
}