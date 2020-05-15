using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0f)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
