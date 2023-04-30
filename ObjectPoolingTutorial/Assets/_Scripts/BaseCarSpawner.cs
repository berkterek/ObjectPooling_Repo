using UnityEngine;

public abstract class BaseCarSpawner : MonoBehaviour
{
    [SerializeField] float _minSpawnRate = 1f;
    [SerializeField] float _maxSpawnRate = 5f;
    [SerializeField] float _randomSpawnRate = 0f;
    [SerializeField] Transform _spanwPoint;
    [SerializeField] protected CarController _carPrefab;
    
    float _currentSpawnRate;
    
    protected virtual void Start()
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
    
    private void SetRandomTime()
    {
        _randomSpawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    protected Vector3 GetRandomPosition()
    {
        Vector3 spawnPointPosition = _spanwPoint.position;
        Vector3 position = new Vector3(Random.Range(spawnPointPosition.x - 5, spawnPointPosition.x + 5), spawnPointPosition.y, spawnPointPosition.z);
        return position;
    }
    
    public abstract void Despawn(CarController carController);
    protected abstract void Spawn();
}