using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour {
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _shootingRatePerSecond = 5f;
    private float _shootingCooldown = 0f;
    private bool _isShooting = false;

    void Update() {
        _shootingCooldown -= Time.deltaTime;
        if (_isShooting && _shootingCooldown <= 0f) {
            ShootBullet();
            _shootingCooldown = 1f / _shootingRatePerSecond;
        }
    }

    // Cette méthode est appelée par le système d'input de Unity quand l'action "Attack" est déclenchée.
    // Notez que le PlayerInput est dans le parent (Player) du GunController et
    // que le message est propagé (broadcast) à tous les enfants.
    void OnAttack(InputValue inputValue) {
        _isShooting = inputValue.isPressed;
    }

    void ShootBullet() {
        GameObject bullet = Instantiate(
            _bulletPrefab,
            _bulletSpawnPoint.position,
            _bulletSpawnPoint.rotation
        );
    }

}
