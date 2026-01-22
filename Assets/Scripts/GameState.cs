using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum State
{
    PLAYER1,
    ENEMY1,
    END
}

public class GameState : MonoBehaviour
{
    [SerializeField]
    private TurnSystem[] m_entities;

    State current;

    private void Start()
    {
        BattleStart();
    }

    public void BattleStart()
    {
        current = State.PLAYER1;
        m_entities[(int)current].StartTurn();
    }

    public Health GetTarget(State t_target)
    {
        switch (t_target)
        {
            case State.PLAYER1:
                return m_entities[(int)State.PLAYER1].GetComponent<Health>();
            case State.ENEMY1:
                return m_entities[(int)State.ENEMY1].GetComponent<Health>();
            default:
                break;
        }
        return m_entities[(int)State.ENEMY1].GetComponent<Health>();
    }

    public void TurnEnd()
    {
        m_entities[(int)current].EndTurn();

        if (current < State.END)
        {
            current++;
        }
        if (current == State.END)
        {
            current = State.PLAYER1;
        }

        StartCoroutine(StartTurn());
    }

    IEnumerator StartTurn()
    {
        yield return new WaitForSeconds(1.0f);
        m_entities[(int)current].StartTurn();
    }
}
