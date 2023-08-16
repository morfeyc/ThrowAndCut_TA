using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
  [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Levels Static Data")]
  public class LevelStaticData : ScriptableObject
  {
    public List<LevelData> LevelsData;
  }

  [Serializable]
  public class LevelData
  {
    public string LevelKey;
    public int LevelNumber;
  }
}