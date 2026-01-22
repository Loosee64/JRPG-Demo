using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField]
    GameState m_gameStateRef;

    private int m_damage;
    private int m_cost;
    private Health m_target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Execute(State t_target, ActionType t_type)
    {
        m_damage = t_type.m_damage;
        m_cost = t_type.m_cost;

        m_target = m_gameStateRef.GetTarget(t_target);
        m_target.Damage(m_damage);

        m_gameStateRef.TurnEnd();
    }
}


