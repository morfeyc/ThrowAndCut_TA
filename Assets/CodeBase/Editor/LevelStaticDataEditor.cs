using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
  [CustomEditor(typeof(LevelStaticData))]
  public class LevelStaticDataEditor : UnityEditor.Editor
  {
    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      LevelStaticData levelStaticData = (LevelStaticData) target;

      if (GUILayout.Button("Add Level"))
      {
        LevelData levelData = new()
        {
          LevelKey = SceneManager.GetActiveScene().name,
          LevelNumber = -1
        };
        
        levelStaticData.LevelsData.Add(levelData);
      }
      
      EditorUtility.SetDirty(target);
    }
  }
}