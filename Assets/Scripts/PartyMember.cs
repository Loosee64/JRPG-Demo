using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [SerializeField]
    private int m_maxSP;
    [SerializeField]
    private ActionType m_type;

    Action m_action;
    TurnSystem m_turn;
    Health m_health;
    CharacterData m_character;

    int m_sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_sp = m_maxSP;
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
        m_health = GetComponent<Health>();
        m_character = GetComponent<CharacterData>();

        m_health.setMax(m_character.GetMax());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string Name()
    {
        return m_character.GetTitle();
    }

    public void Attack()
    {
        if (m_turn.TurnCheck())
        {
            m_action.Execute(State.ENEMY1, m_type);
        }
    }
}
