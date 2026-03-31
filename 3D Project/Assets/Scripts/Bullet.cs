using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody _rb;
    [SerializeField] private float _speedPerSecond = 10f;
    [SerializeField] private int _damage = 1;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        // Détruit la balle après 5 secondes pour éviter d'avoir trop d'objets dans la scène
        Destroy(gameObject, 5f);
    }

    void FixedUpdate() {
        // La balle se déplace toujours dans la direction de son forward (son axe z local)
        _rb.MovePosition(_rb.position + transform.forward 
            * _speedPerSecond * Time.fixedDeltaTime);

     
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
