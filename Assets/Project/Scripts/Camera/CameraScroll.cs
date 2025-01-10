using UnityEngine;

namespace Project
{
    public class CameraScroll : MonoBehaviour
    {
        private Vector3 WorldMousePosition => _camera.ScreenToWorldPoint(_input.ScreenMousePosition);
        private bool CanScrolling => !_dragHandler.IsDragging && _isScrolling;

        private IInput _input;
        private Camera _camera;
        private DragHandler _dragHandler;
        private LevelBounds _levelBounds;

        private bool _isScrolling;
        private Vector3 _scrollOrigin;

        public void Construct(IInput input, Camera camera, DragHandler dragHandler, LevelBounds levelBounds)
        {
            _input = input;
            _camera = camera;
            _dragHandler = dragHandler;
            _levelBounds = levelBounds;
        }

        private void OnEnable()
        {
            _input.LeftMouseButtonPressed += PrepareScroll;
            _input.LeftMouseButtonReleased += CancelScroll;
        }

        private void OnDisable()
        {
            _input.LeftMouseButtonPressed -= PrepareScroll;
            _input.LeftMouseButtonReleased -= CancelScroll;
        }

        private void LateUpdate()
        {
            if (CanScrolling)
                Scroll();
        }

        private void Scroll()
        {
            Vector3 offset = WorldMousePosition - _camera.transform.position;
            Vector3 targetPosition = _scrollOrigin - offset;
            _camera.transform.position = GetClampedTargetPosition(targetPosition);
        }

        private Vector3 GetClampedTargetPosition(Vector3 targetPosition)
        {
            (float min, float max) bounds = _levelBounds.GetMinAndMaxBoundsOnX();
            float halfWidth = _camera.aspect * _camera.orthographicSize;
            float clampedX = Mathf.Clamp(targetPosition.x, bounds.min + halfWidth, bounds.max - halfWidth);

            return targetPosition.With(x: clampedX, y: _camera.transform.position.y);
        }

        private void PrepareScroll()
        {
            _scrollOrigin = WorldMousePosition;
            _isScrolling = true;
        }

        private void CancelScroll() =>
            _isScrolling = false;
    }
}
