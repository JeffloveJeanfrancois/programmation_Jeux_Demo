using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    [Tooltip("Nombre d'ennemis à spawner par seconde")]
    private float _spawnRate = 1;
    [SerializeField] private Enemy _enemyPrefab;
    private float _timeLeftBeforeSpawn = 0;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemySo[] _enemySos;

    void Start() {
        _spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        _player = GameObject.FindGameObjectWithTag("Player");
        _timeLeftBeforeSpawn = 1 / _spawnRate;
    }

    void Update() {
        UpdateSpawn();
    }

    private void UpdateSpawn() {
        _timeLeftBeforeSpawn -= Time.deltaTime;
        if (_timeLeftBeforeSpawn <= 0) {
            SpawnEnemy();
            _timeLeftBeforeSpawn = 1 / _spawnRate;
        }
    }

    private void SpawnEnemy() {
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

      Enemy enemy =  Instantiate(
            _enemyPrefab,
            spawnPoint.transform.position,
            Quaternion.LookRotation(
                _player.transform.position -
                spawnPoint.transform.position
                )
            );
        enemy.Init(GetRandomEnemySo());
        
    }

    private SpawnPoint GetRandomSpawnPoint() {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
    private EnemySo GetRandomEnemySo() {
        return _enemySos[Random.Range(0, _enemySos.Length)];
    }
}