using UnityEngine.Pool;

public class UnityPoolCarSpawner : BaseCarSpawner
{
    IObjectPool<CarController> _pool1;

    void Awake()
    {
        _pool1 = new ObjectPool<CarController>(() =>
        {
            var carObject =Instantiate(_carPrefab);
            carObject.gameObject.SetActive(false);
            carObject.transform.SetParent(this.transform);
            return carObject;
        },defaultCapacity:5);
    }

    public override void Despawn(CarController carController)
    {
        carController.gameObject.SetActive(false);
        _pool1.Release(carController);
    }

    protected override void Spawn()
    {
        var poolObject = _pool1.Get();
        poolObject.transform.position = GetRandomPosition();
        poolObject.gameObject.SetActive(true);
    }
}