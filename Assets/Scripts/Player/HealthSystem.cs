using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealth
{
    [SerializeField]private int currentHealth;

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int value)
    {
        currentHealth = value;
    }

    public void ApplyDamage(int value)
    {
        currentHealth -= value;
    }
}
