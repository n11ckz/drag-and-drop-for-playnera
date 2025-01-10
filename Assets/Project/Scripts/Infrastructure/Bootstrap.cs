using UnityEngine;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private DragConfig _dragConfig;
        [SerializeField] private DragHandler _dragHandler;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private CameraScroll _cameraScroll;

        private IInput _input;

        private void Awake()
        {
            Camera camera = Camera.main;

            _input = new UniversalInput();

            _dragHandler.Construct(_input, camera, _dragConfig);
            _cameraScroll.Construct(_input, camera, _dragHandler, _levelBounds);
        }

        // Если проект будет расширяться, можно подлючить зенжект, и сделать через него, а пока не ругайтесь :)
        private void Update()
        {
            IUpdatable updatable = _input as IUpdatable;
            updatable.Update();
        }
    }
}
