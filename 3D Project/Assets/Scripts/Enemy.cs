using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public abstract class Enemy : MonoBehaviour, IDamageable {
    protected Rigidbody _rb;
    private int _currentHealth;
    protected abstract void Die();
    //[SerializeField] private int _maxHealth = 3;
    //[SerializeField] private float _speed = 1;
    //[SerializeField] private Color _color = Color.red;
    protected EnemySo _enemySo;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        EnemyStart();

    }
    protected abstract void EnemyStart();

    public void Init(EnemySo enemySo) {
        _enemySo = enemySo;
        _currentHealth = _enemySo.Health;
        GetComponent<Renderer>().material.color = _enemySo.color;
    }
    public void TakeDamage(int damage) { 
        _currentHealth -= damage;
        if (_currentHealth <= 0) {
            Die();
        }
    }
}