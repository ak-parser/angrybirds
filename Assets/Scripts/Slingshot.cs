using Assets.Scripts;
using Assets.Scripts.Factory;
using Assets.Scripts.Factory.Birds;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slingshot : MonoBehaviour
{
    const int MAX_BIRD_COUNT = 3;

    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;

    private IAbstractFactory _factory;

    public float birdPositionOffset;

    Rigidbody2D bird;
    Collider2D birdCollider;

    private int _birdCount;
    private bool _initialized = false;

    [SerializeField] private float _force;

    void Start()
    {
        Invoke("Initialize", (float)0.1);
    }

    void Initialize()
    {
        _factory = Singleton.Instance.AbstractFactory;

        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        _birdCount = 0;

        CreateBird();

        _initialized = true;
        Singleton.Instance.BottomBoundary = bottomBoundary;
    }

    void CreateBird()
    {
        bird = _factory.CreateBird().gameObject.GetComponent<Rigidbody2D>();
        birdCollider = bird.GetComponent<Collider2D>();
        birdCollider.enabled = false;

        bird.isKinematic = true;

        _birdCount++;

        ResetStrips();
    }

    void Update()
    {
        if (!_initialized)
            return;

        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
            if (_birdCount >= MAX_BIRD_COUNT && !bird.isKinematic && (bird.velocity.magnitude < 0.001 || isOutside(bird.position)))
            {
                Singleton.Instance.Bird = null;
                Singleton.Instance.LevelManager.ReloadCurrentLevel();
            }
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        bird.isKinematic = false;
        Vector3 birdForce = (currentPosition - center.position) * _force * -1;
        bird.velocity = birdForce;

        bird.GetComponent<IBird>().Release();

        if (_birdCount < MAX_BIRD_COUNT)
        {
            Invoke("CreateBird", 2);
        }
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bird.isKinematic)
        {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionOffset;
            bird.transform.right = -dir.normalized;
        }
    }

    private Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }

    private bool isOutside(Vector3 vector)
    {
        return vector.x < -10 || vector.x > 20 || vector.y < -4 || vector.y > 10;
    }
}
