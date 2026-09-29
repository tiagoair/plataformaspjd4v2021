using UnityEngine;
using UnityEngine.Pool;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool Instance;
    
    public ObjectPool<EnemyBulletController> eBulletPool;

    [SerializeField] private GameObject eBulletPrefab;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            eBulletPool = new ObjectPool<EnemyBulletController>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet, 
                false, 30, 100);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private EnemyBulletController CreateBullet()
    {
       return Instantiate(eBulletPrefab, transform).GetComponent<EnemyBulletController>();;
    }

    private void GetBullet(EnemyBulletController bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void ReleaseBullet(EnemyBulletController bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(transform);
    }

    private void DestroyBullet(EnemyBulletController bullet)
    {
        Destroy(bullet.gameObject);
    }
}
