using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Assets.Scripts.Factory.Pigs;
using System.Collections.Generic;

public class BombPig : MonoBehaviour, IPig
{
    [SerializeField] private float _explosionPower = 300;
    [SerializeField] private float _explosionRadius = 10;
    public GameObject explosionParticle;

    private void Start()
    {
        Singleton.Instance.Pigs.Add(this);
    }

    private void OnDestroy()
    {
        Singleton.Instance.Pigs.Remove(this);
        if (Singleton.Instance.Pigs.Count == 0)
            Singleton.Instance.LevelManager.LoadNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Singleton.Instance.Strategy.CheckDestructiveColision(collision))
            Explose();
    }

    private void Explose()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        Physics2D.OverlapCollider(GetComponent<PolygonCollider2D>(), new ContactFilter2D().NoFilter(), colliders);

        foreach (var hit in colliders)
        {
            if (hit.attachedRigidbody)
            {
                hit.attachedRigidbody.AddExplosionForce(_explosionPower, transform.position, _explosionRadius);
            }
        }

        GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosion, 1);

        Destroy(gameObject);
    }
}
