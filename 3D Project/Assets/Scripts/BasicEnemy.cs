using UnityEngine;

public  class BasicEnemy: Enemy
{
    private GameObject _player;
    protected  override void EnemyStart()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        _rb.MovePosition(Vector3.MoveTowards(
            _rb.position,
            _player.transform.position,
            _enemySo.speed * Time.fixedDeltaTime
            )

         );

        _rb.MoveRotation(
            Quaternion.LookRotation(_player.transform.position - transform.position
            )
         );
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
