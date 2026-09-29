using UnityEngine;
using UnityEngine.Pool;

public class EnemyBulletController : MonoBehaviour
{
    public float moveSpeed;

    public int damage;
    
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private GameObject bulletExplosion;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject,2f);
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        _rigidbody2D.linearVelocity = transform.localScale.x * transform.right * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>().TakeEnergy(damage);
            Instantiate(bulletExplosion, transform.position, Quaternion.identity);
            EnemyBulletPool.Instance.eBulletPool.Release(this);
        }

        if (other.CompareTag("Ground"))
        {
            Instantiate(bulletExplosion, transform.position, Quaternion.identity);
            EnemyBulletPool.Instance.eBulletPool.Release(this);
        }
    }
}
