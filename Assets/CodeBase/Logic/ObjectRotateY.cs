﻿using UnityEngine;

namespace CodeBase.Logic
{
  public class ObjectRotateY : MonoBehaviour
  {
    [SerializeField] private float _speed;
    
    private void Update()
    {
      transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
  }
}