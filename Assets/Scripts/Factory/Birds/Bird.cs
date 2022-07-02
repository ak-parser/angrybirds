using Assets.Scripts;
using Assets.Scripts.Factory.Birds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IBird
{
    [SerializeField] private bool _collided;

    public IBird Clone()
    {
        GameObject clone = Instantiate(gameObject);
        clone.transform.position += new Vector3(0, 2);
        clone.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        return clone.GetComponent<Bird>();
    }

    public void Release()
    {
        Singleton.Instance.Bird = this;
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints());
    }

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (_collided) break;
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collided = true;
        if ((Object)Singleton.Instance.Bird == this)
            Singleton.Instance.Bird = null;
    }
}
