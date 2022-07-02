using Assets.Scripts;
using Assets.Scripts.Factory;
using Assets.Scripts.Factory.Pigs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PigsController : MonoBehaviour
{
    [SerializeField] private List<Transform> _positions;
    private IAbstractFactory _factory;
    private bool _initialized = false;

    void Start()
    {
        Invoke("Initialize", (float)0.1);
    }

    void Initialize()
    {
        _factory = Singleton.Instance.AbstractFactory;

        foreach (var position in _positions)
        {
            IPig pig = _factory.CreatePig();
            pig.gameObject.transform.position = position.position;
        }

        _initialized = true;
    }

    private void Update()
    {
        if (!_initialized)
            return;

        foreach (var pig in Singleton.Instance.Pigs)
            if (isOutside(pig.gameObject.transform.position))
                Destroy(pig.gameObject);
    }

    private bool isOutside(Vector3 vector)
    {
        return vector.x < -10 || vector.x > 20 || vector.y < -4 || vector.y > 10;
    }
}
