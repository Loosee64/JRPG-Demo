using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [SerializeField]
    private int m_maxSP;
    [SerializeField]
    private ActionType m_type;

    Action m_action;
    TurnSystem m_turn;

    int m_sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_sp = m_maxSP;
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack()
    {
        if (m_turn.TurnCheck())
        {
            m_action.Execute(State.ENEMY1, m_type);
        }
    }
}
