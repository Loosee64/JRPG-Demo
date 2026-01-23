using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ActionType m_type;

    Action m_action;
    TurnSystem m_turn;
    Health m_health;
    CharacterData m_character;

    public UnityEvent m_deadEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
        m_health = GetComponent<Health>();
        m_character = GetComponent<CharacterData>();

        m_health.setMax(m_character.GetMax());

        m_deadEvent.AddListener(() => GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().DisplayDeath(m_character.GetTitle()));
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
            m_deadEvent.Invoke();
            StartCoroutine(SpawnEnemy());
        }
    }

    public string Name()
    {
        return m_character.GetTitle();
    }

    public void NewEnemy()
    {
        m_character.NewRandom();
        m_health.setMax(m_character.GetMax());
        m_health.FullHeal();
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.0f);
        NewEnemy();
    }
}
