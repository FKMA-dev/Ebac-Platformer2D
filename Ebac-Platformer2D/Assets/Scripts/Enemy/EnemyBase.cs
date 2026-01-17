using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int damage = 10;
    public string attackTrigger = "Attack";
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

       
        if (health != null)
        {
            health.Damage(damage);
            AttackAnimation();
        }

    }

    public void AttackAnimation()
    {
        animator.SetTrigger(attackTrigger);
    }

}
