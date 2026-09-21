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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private EnemyBulletController CreateBullet()
    {
        return Instantiate(eBulletPrefab, transform).GetComponent<EnemyBulletController>();
    }

    private void GetBullet(EnemyBulletController bullet)
    {
        
    }
    
}
