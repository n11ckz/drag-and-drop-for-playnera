using System;
using UnityEngine;

namespace Project
{
    public interface IInput
    {
        public event Action LeftMouseButtonPressed;
        public event Action LeftMouseButtonReleased;

        public Vector2 ScreenMousePosition { get; }
    }
}
