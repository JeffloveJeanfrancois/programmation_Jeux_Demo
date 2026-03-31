using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CursorHover))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float _moveSpeedPerSecond = 5f;
    private Rigidbody _rb;
    private CursorHover _cursorHover;
    private Vector2 _moveDirection;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _cursorHover = GetComponent<CursorHover>();
    }

    void FixedUpdate() {
        Move();
        OrientatePlayer();
    }

    void OnMove(InputValue inputValue) {
        _moveDirection = inputValue.Get<Vector2>();
    }

    void Move() {
        Vector3 distance = new Vector3(
            _moveDirection.x,
            0,
            _moveDirection.y
        ) * _moveSpeedPerSecond * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + distance);
    }

    void OrientatePlayer() {
        if (!_cursorHover.IsHovering) { return; }

        Vector3 directionVector = new Vector3(
            _cursorHover.Position.x,
            _rb.position.y,
            _cursorHover.Position.z
        ) - transform.position;

        Quaternion quaternionRotation = Quaternion.LookRotation(
            directionVector, Vector3.up
        );

        _rb.MoveRotation(quaternionRotation);
    }
}
