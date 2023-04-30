using UnityEngine;

[AddComponentMenu("Terek Gaming/Controllers/Car Controller")]
public class CarController : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _moveSpeed = 5f;

    void OnValidate()
    {
        if (_transform == null)
        {
            _transform = GetComponent<Transform>();
        }
    }

    void Update()
    {
        _transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseCarSpawner carSpawner))
        {
            carSpawner.Despawn(this);
        }
    }
}
