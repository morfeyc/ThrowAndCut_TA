using System;

namespace CodeBase.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public int CurrentLevelId;
    public LevelTask LevelTask;
    
    public PlayerProgress()
    {
      CurrentLevelId = 0;
      LevelTask = new LevelTask(-1);
    }
  }
}