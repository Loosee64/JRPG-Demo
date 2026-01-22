using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int m_maxHealth;
    [SerializeField]
    private HealthBarUI m_healthBarUI;
    
    private TextMeshProUGUI m_text;

    int m_health;

    private void Start()
    {
        m_text = m_healthBarUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setMax(int t_amount)
    {
        m_maxHealth = t_amount;
        m_health = m_maxHealth;
        m_healthBarUI.setMax(m_maxHealth);
        m_text.text = m_health.ToString() + "/" + m_maxHealth.ToString();
    }

    public void Damage(int t_damage)
    {
        if (m_health > 0)
        {
            m_health -= t_damage;
            m_healthBarUI.setHealth(m_health);
            m_text.text = m_health.ToString() + "/" + m_maxHealth.ToString();
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
