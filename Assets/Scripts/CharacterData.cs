using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    CharacterType m_character;

    int maxHealth;
    string title;

    private void Start()
    {
        maxHealth = m_character.maxHealth;
        title = m_character.title;
    }

    public int GetMax() { return maxHealth; }
    public string GetTitle() { return title; }

}
