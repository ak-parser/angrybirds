using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Assets.Scripts.Factory.Pigs;

public class Pig : MonoBehaviour, IPig
{
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
        {
            Destroy(gameObject);
        }
    }
}
