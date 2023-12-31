﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lib.Joystick_Pack
{
    public class JoyStick : MonoBehaviour
    {
        public static bool Enabled = true;
        public static bool Active => _handle != null && _handle.gameObject.activeSelf;
        public static bool StartDragging = false;
        public static bool EndDragging = false;

        private static Transform _handle;
        
        public static Vector2 Move => (_handle.transform.localPosition / (Vector2.one * 100f));
        
        [SerializeField] private Transform Handle;
        [SerializeField] private bool ActiveSelf;
        private Vector3 _start;

        private void Start()
        {
            _handle = Handle;
        }

        private void Update()
        {
            StartDragging = false;
            EndDragging = false;
            
            if (!Enabled)
            {
                Hide();
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _start = Input.mousePosition;
                Handle.gameObject.SetActive(true);
                StartDragging = true;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = Input.mousePosition - _start;
                direction = Vector3.ClampMagnitude(direction, 100f);
                Handle.localPosition = direction;
                if (direction.magnitude > 20f)
                {
                    transform.position = _start;
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                Hide();
                EndDragging = true;
            }
            else
            {
                Hide();
            }
            
            ActiveSelf = Active;
        }

        private void Hide()
        {
            transform.position = Vector3.up * 99999f;
            Handle.localPosition = Vector3.zero;
            Handle.gameObject.SetActive(false);
        }
    }
}