using UnityEngine;


internal sealed class MainBuilding : MonoBehaviour
{

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;


    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, 
            new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), 
            Quaternion.identity,
            _unitsParent);
    }

}
