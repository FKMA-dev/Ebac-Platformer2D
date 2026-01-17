using UnityEngine;

public class HealthBase : MonoBehaviour
{

    public int startLife = 10;
    private int _currentLife;
    public float delayToDestroy;
    [SerializeField] private FlashDamage _flashDamage;

    private bool _isDead = false;
    public bool _destroyOnKill = false;

    private void Awake()
    {
        Initial();
        if(_flashDamage == null)
        {
            _flashDamage = GetComponent<FlashDamage>();
        }
    }

    private void Initial()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        if(_flashDamage != null)
        {
            _flashDamage.Flash();
        }
    }
    
    private void Kill()
    {
        _isDead = true;

        if (_destroyOnKill)
        {
            Destroy(gameObject, delayToDestroy);
        }
    }

}
