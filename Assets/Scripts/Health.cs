using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int m_maxHealth;
    [SerializeField]
    private HealthBarUI m_healthBarUI;

    int m_health;

    private void Start()
    {
        m_health = m_maxHealth;
        m_healthBarUI.setMax(m_maxHealth);
    }

    public void Damage(int t_damage)
    {
        if (m_health > 0)
        {
            m_health -= t_damage;
            m_healthBarUI.setHealth(m_health);
            Debug.Log("damage");
        }
    }

    public bool IsAlive()
    {
        if (m_health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
