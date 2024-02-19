using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [base class for all UFO enemies]
 */

public class BaseUFOScript : BaseEnemyScript
{
    //needed components
    Rigidbody _rigidbody;

    //variables for Shoot()
    protected bool _inCooldown = false;
    [SerializeField] protected float _cooldownTime = 1.75f;

    //Prefab for bullet
    [SerializeField] protected GameObject _bulletPrefab;

    //move var
    protected bool _ready = false;
    protected bool _goingRight = true;
    protected bool _attemptingManuvers = false;
    protected float _minRandDelay = 0f;
    protected float _maxRandDelay = 3f;

    /// <summary>
    /// on awake,
    /// get needed components
    /// randomly assign if it goes left or right
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        int randomNum = Random.Range(0,2);
        if (randomNum == 0)
        {
            _goingRight = false;

            _speed = _speed * -1;
        }
    }

    /// <summary>
    /// one every frame,
    /// calls to move every frame
    /// calls to shoot every frame
    /// </summary>
    protected virtual void Update()
    {
        if (_ready)
        {
            Move();
            Shoot();
        }
    }

    /// <summary>
    /// Player moves from one side of the screen to the other
    /// </summary>
    protected void Move()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (!_attemptingManuvers)
        {
            StartCoroutine(RandomMovement());
        }

        CheckOffScreen();
    }

    /// <summary>
    /// called in update to start shoot cooldown
    /// meant to be inherited then called base.Shoot()
    /// </summary>
    protected virtual void Shoot() 
    {
        if (!_inCooldown)
        {
            StartCoroutine(Cooldown());
        }
    }

    protected void CheckOffScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (!goingRight && screenPos.x <= 0)
        {
            Destroy(gameObject);
        }
        else if (goingRight && screenPos.x >= Screen.width)
        {
            Destroy(gameObject);
        }
    }

    public void Ready()
    {
        _ready = true;
    }

    /// <summary>
    /// when called, UFO cant shoot until coroutine ends
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Cooldown()
    {
        _inCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _inCooldown = false;
    }

    /// <summary>
    /// when called, set velocity up, down or zero
    /// </summary>
    /// <returns></returns>
    protected IEnumerator RandomMovement()
    {
        _attemptingManuvers = true;
        yield return new WaitForSeconds(Random.Range(_minRandDelay, _maxRandDelay));

        int randomNum = Random.Range(0, 3);
        switch (randomNum)
        {
            case 0:
                _rigidbody.velocity = Vector3.zero;
                break;
            case 1:
                _rigidbody.velocity = Vector3.up * _speed;
                break;
            case 2:
                _rigidbody.velocity = Vector3.down * _speed;
                break;
            default:
                break;
        }
        _attemptingManuvers = false;
    }

    public bool goingRight
    {
        get { return _goingRight; }
    }
}
