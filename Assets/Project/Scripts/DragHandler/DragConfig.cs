using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(DragConfig), fileName = nameof(DragConfig))]
    public class DragConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.0f, 0.1f)] public float Smoothness { get; private set; }
    }
}
