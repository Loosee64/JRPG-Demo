using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    CharacterType m_character;

    CharacterType[] m_allTypes;

    int maxHealth;
    string title;

    private void Awake()
    {
        maxHealth = m_character.maxHealth;
        title = m_character.title;
    }

    public void NewRandom()
    {
        m_allTypes = Resources.LoadAll<CharacterType>("ScriptableObjects/Characters/Enemy");
        m_character = m_allTypes[Random.Range(0, m_allTypes.Length)];

        maxHealth = m_character.maxHealth;
        title = m_character.title;
    }

    public int GetMax() { return maxHealth; }
    public string GetTitle() { return title; }

}
