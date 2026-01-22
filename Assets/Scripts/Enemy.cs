using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ActionType m_type;

    Action m_action;
    TurnSystem m_turn;
    Health m_health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
        m_health = GetComponent<Health>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (m_turn.TurnCheck() && m_health.IsAlive())
        {
            m_action.Execute(State.PLAYER1, m_type);
        }
        else if (!m_health.IsAlive())
        {
            Debug.Log("Dead");
        }
    }

    
}
