using System.Collections.Generic;
using UnityEngine;

public class CustomCarSpawner : BaseCarSpawner
{
    [SerializeField] int _poolSize = 10;
    Queue<CarController> _pool1;

    void Awake()
    {
        _pool1 = new Queue<CarController>();
    }

    protected override void Start()
    {
        base.Start();
        GrowPool();
    }

    private void GrowPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var carObject = Instantiate(_carPrefab, transform);
            carObject.gameObject.SetActive(false);
            _pool1.Enqueue(carObject);    
        }
    }

    public override void Despawn(CarController carController)
    {
        carController.gameObject.SetActive(false);
        _pool1.Enqueue(carController);
    }

    protected override void Spawn()
    {
        if (_pool1.Count <= 0)
        {
            GrowPool();
        }
        
        var carPoolObject = _pool1.Dequeue();
        carPoolObject.transform.position = GetRandomPosition();
        carPoolObject.gameObject.SetActive(true);
    }
}