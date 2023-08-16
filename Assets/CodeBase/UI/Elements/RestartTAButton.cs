using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
  public class RestartTAButton : MonoBehaviour
  {
    [SerializeField] private Button Button;
    
    private void Awake() =>
      Button.onClick.AddListener(Reload);

    private void OnDestroy() =>
      Button.onClick.RemoveAllListeners();

    private void Reload()
    {
      PlayerPrefs.DeleteAll();
      Application.Quit();
    }

    private void Reset() => 
      Button = GetComponent<Button>() 
               ?? null;
  }
}