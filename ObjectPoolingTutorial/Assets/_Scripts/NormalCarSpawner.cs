using UnityEngine;

public class NormalCarSpawner : BaseCarSpawner
{
    protected override void Spawn()
    {
        Vector3 position = GetRandomPosition();
        var carObject = Instantiate(_carPrefab, position, Quaternion.identity);
        carObject.transform.SetParent(this.transform);
    }

    public override void Despawn(CarController carController)
    {
        Destroy(carController.gameObject);
    }
}