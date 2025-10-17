using UnityEngine;

public class HealthBase : MonoBehaviour
{

    public int startLife = 10;
    private int _currentLife;
    public float delayToDestroy;

    private bool _isDead = false;
    public bool _destroyOnKill = false;

    private void Awake()
    {
        Initial();
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
