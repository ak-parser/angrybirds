using Assets.Scripts;
using Assets.Scripts.Factory.Birds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChuckBird : MonoBehaviour, IBird
{
    [SerializeField] private bool _collided;
    [SerializeField] private float _boostedForce = 3;
    private bool _boosted = false;

    public IBird Clone()
    {
        GameObject clone = Instantiate(gameObject);
        clone.transform.position += new Vector3(0, 2);
        clone.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        return clone.GetComponent<ChuckBird>();
    }

    private void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (!_collided && !_boosted && !rigidbody.isKinematic && Input.GetMouseButtonDown(0) && 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y > Singleton.Instance.BottomBoundary)
        {
            rigidbody.velocity *= _boostedForce;
            _boosted = true;
        }
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
