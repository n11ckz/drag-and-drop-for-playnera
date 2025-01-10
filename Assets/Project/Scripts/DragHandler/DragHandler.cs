using UnityEngine;

namespace Project
{
    public class DragHandler : MonoBehaviour
    {
        public bool IsDragging => _currentDraggableItem != null;

        private IInput _input;
        private Camera _camera;
        private DragConfig _config;

        private IDragListener _currentDraggableItem;
        private Vector2 _velocity;

        public void Construct(IInput input, Camera camera, DragConfig config)
        {
            _input = input;
            _camera = camera;
            _config = config;
        }

        private void OnEnable()
        {
            _input.LeftMouseButtonPressed += TryCaptureDraggableItem;
            _input.LeftMouseButtonReleased += CancelDrag;
        }

        private void OnDisable()
        {
            _input.LeftMouseButtonPressed -= TryCaptureDraggableItem;
            _input.LeftMouseButtonReleased -= CancelDrag;
        }

        private void Update() =>
            TryDrag();

        private void TryDrag()
        {
            if (IsDragging == false)
                return;

            Vector2 targetPosition = _camera.ScreenToWorldPoint(_input.ScreenMousePosition);
            Vector2 position = Vector2.SmoothDamp(_currentDraggableItem.Transform.position, targetPosition, ref _velocity, _config.Smoothness);

            _currentDraggableItem.Transform.position = position;
        }

        private void TryCaptureDraggableItem()
        {
            RaycastHit2D hit = GetRaycastHitBy(_input.ScreenMousePosition);

            if (hit == false || hit.collider.TryGetComponentInParent(out IDragListener draggable) == false)
                return;

            _currentDraggableItem = draggable;

            if (_currentDraggableItem is IBeginDragListener other)
                other.OnBeginDrag();
        }

        private void CancelDrag()
        {
            if (IsDragging && _currentDraggableItem is IEndDragListener other)
                other.OnEndDrag();

            _currentDraggableItem = null;
        }

        private RaycastHit2D GetRaycastHitBy(Vector2 screenMousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenMousePosition);
            return Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        }
    }
}
