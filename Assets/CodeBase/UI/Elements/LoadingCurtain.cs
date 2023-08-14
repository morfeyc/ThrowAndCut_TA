using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Elements
{
  public class LoadingCurtain : MonoBehaviour
  {
    [SerializeField] private CanvasGroup CanvasGroup;
    [SerializeField] private float FadeInSpeed = 0.03f;
    
    private void Awake() => 
      DontDestroyOnLoad(this);

    public void Show()
    {
      gameObject.SetActive(true);
      CanvasGroup.alpha = 1;
    }
    
    public void Hide() => 
      DoFadeIn().Forget();
    
    private async UniTaskVoid DoFadeIn()
    {
      while (CanvasGroup.alpha > 0)
      {
        CanvasGroup.alpha -= FadeInSpeed;
        await UniTask.Delay(TimeSpan.FromSeconds(FadeInSpeed));
      }
      
      gameObject.SetActive(false);
    }
  }
}