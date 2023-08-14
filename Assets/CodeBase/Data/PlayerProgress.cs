using System;

namespace CodeBase.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public int CurrentLevelId;
    
    public PlayerProgress()
    {
      CurrentLevelId = 0;
    }
  }
}