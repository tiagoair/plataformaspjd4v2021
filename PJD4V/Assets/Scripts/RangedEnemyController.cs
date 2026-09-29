using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public int maxEnergy;
    public int bulletDamage;
    public bool shouldFlip;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject muzzlePrefab;
    
    private Animator _animator;
    private bool _isShooting;
    private bool _shotMade;
    
    
    private void Shooting()
    {
        if (_isShooting)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("JumpShoot") ||
                _animator.GetCurrentAnimatorStateInfo(0).IsName("IdleShoot") ||
                _animator.GetCurrentAnimatorStateInfo(0).IsName("WalkShoot"))
            {
                GameObject newBullet = Instantiate(bulletPrefab, shootOrigin.transform.position, Quaternion.identity);
                newBullet.transform.localScale = transform.localScale;
                newBullet.gameObject.GetComponent<BulletController>().damage = bulletDamage;

                GameObject muzzle = Instantiate(muzzlePrefab, shootOrigin.transform.position, Quaternion.identity);
                _isShooting = false;
                _shotMade = true;
            }
        } else if (_shotMade)
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("JumpShoot") &&
                !_animator.GetCurrentAnimatorStateInfo(0).IsName("IdleShoot") &&
                !_animator.GetCurrentAnimatorStateInfo(0).IsName("WalkShoot"))
            {
                _shotMade = false;
            }
        }
    }
}
