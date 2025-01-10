using UnityEngine;

namespace Project
{
    public class CameraConstantWidth : MonoBehaviour
    {
        [SerializeField] private Vector2 _defaultResolution;
        [SerializeField] private Camera _camera;

        private void Awake() => Initialize();

        private void Initialize()
        {
            float initialSize = _camera.orthographicSize;
            float aspect = _defaultResolution.x / _defaultResolution.y;
            _camera.orthographicSize = initialSize * (aspect / _camera.aspect);
        }
    }
}
