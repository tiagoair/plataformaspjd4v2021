using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    public int maxEnergy;
    
    public float moveSpeed;
    public bool useTransform;
    public bool shouldFlip;
    
    [SerializeField] private Vector2 movePosition;
    [SerializeField] private Transform moveDestination;
    
    private Vector2 _initialPosition;

    private Vector2 _moveTarget;
    
    private Vector2 _currentMoveDirection;
    
    private bool _isReturning;

    private float _originalLocalScaleX;
    
    private int _currentEnergy;
    
    // Start is called before the first frame update
    void Start()
    {
        if (shouldFlip) _originalLocalScaleX = transform.localScale.x;
        
        if (useTransform)
        {
            _moveTarget = moveDestination.localPosition;
        }
        else
        {
            _moveTarget = movePosition;
        }
        _initialPosition = transform.position;
        _currentMoveDirection = (_initialPosition + _moveTarget - (Vector2) transform.position).normalized;

        _currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (!_isReturning)
        {
            if (Vector2.Distance(transform.position, _initialPosition + _moveTarget) < 1f)
            {
                _isReturning = true;
                _currentMoveDirection = (_initialPosition - (Vector2) transform.position).normalized;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, _initialPosition) < 1f)
            {
                _isReturning = false;
                _currentMoveDirection = (_initialPosition + _moveTarget - (Vector2) transform.position).normalized;
            }
        }

        if (shouldFlip)
        {
            if (_isReturning)
                transform.localScale =
                    new Vector3(-_originalLocalScaleX, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(_originalLocalScaleX, transform.localScale.y, transform.localScale.z);
        }

        transform.position += (Vector3)_currentMoveDirection * moveSpeed * Time.deltaTime;
    }

    private void TakeEnergy(int damage)
    {
        _currentEnergy -= damage;

        if (_currentEnergy <= 0)
        {
            //TODO: Gerenciar morte  do inimigo
            _currentEnergy = 0;
            Destroy(gameObject);
        }

        if (_currentEnergy > maxEnergy) _currentEnergy = maxEnergy;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeEnergy(10);
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (useTransform)
        {
            Debug.DrawLine(transform.position, transform.position + moveDestination.localPosition, Color.yellow);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)movePosition, Color.red);
        }
        
    }
}
