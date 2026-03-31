using UnityEngine;
using UnityEngine.InputSystem;

public class CursorHover : MonoBehaviour {
    private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    public bool IsHovering { get; private set; }
    public Vector3 Position { get; private set; }

    private void Start() {
        _camera = Camera.main;
    }

    void Update() {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue()
            );
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _layerMask))
        {
            IsHovering = true;
            Position = hit.point;
            return;
        }
        IsHovering = false;
    }
}
