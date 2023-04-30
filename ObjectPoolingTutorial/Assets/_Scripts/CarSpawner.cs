using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float _minSpawnRate = 1f;
    [SerializeField] float _maxSpawnRate = 5f;
    [SerializeField] float _randomSpawnRate = 0f;
    [SerializeField] Transform _spanwPoint;
    [SerializeField] CarController[] _carPrefabs;

    float _currentSpawnRate;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        _currentSpawnRate += Time.deltaTime;

        if (_currentSpawnRate > _randomSpawnRate)
        {
            _currentSpawnRate = 0f;
            SetRandomTime();
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnPointPosition = _spanwPoint.position;
        Vector3 position = new Vector3(Random.Range(spawnPointPosition.x - 5, spawnPointPosition.x + 5),
            spawnPointPosition.y, spawnPointPosition.z);
        Instantiate(_carPrefabs[Random.Range(0, _carPrefabs.Length)],position , Quaternion.identity);
    }

    private void SetRandomTime()
    {
        _randomSpawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    public void Despawn(CarController carController)
    {
        Destroy(carController.gameObject);
    }
}
