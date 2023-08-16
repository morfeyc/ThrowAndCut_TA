using System;

namespace CodeBase.Data
{
  [Serializable]
  public class LevelTask
  {
    public int AmountToComplete { get; set; }
    public int CurrentAmount { get; private set; }

    public Action OnCompleted;
    public Action OnFruitSliced;

    public LevelTask(int amountToComplete)
    {
      AmountToComplete = amountToComplete;
    }

    public void FruitSliced()
    {
      CurrentAmount++;
      OnFruitSliced?.Invoke();
      
      if (CurrentAmount == AmountToComplete) 
        OnCompleted?.Invoke();
    }
  }
}