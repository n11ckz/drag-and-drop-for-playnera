using System;
using UnityEngine;

namespace Project
{
    public class UniversalInput : IInput, IUpdatable
    {
        private const int LeftMouseButton = 0;

        public event Action LeftMouseButtonPressed;
        public event Action LeftMouseButtonReleased;

        public Vector2 ScreenMousePosition => Input.mousePosition;

        public void Update()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
                LeftMouseButtonPressed?.Invoke();

            if (Input.GetMouseButtonUp(LeftMouseButton))
                LeftMouseButtonReleased?.Invoke();
        }
    }
}
