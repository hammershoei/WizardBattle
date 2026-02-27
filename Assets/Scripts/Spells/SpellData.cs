using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spells/Spell")]
public class SpellData : ScriptableObject
{
    public string spellName;
    public List<KeyCode> sequence; 
    public GameObject prefab;
    public float manaCost;
    public float damage;
    public float range;
}