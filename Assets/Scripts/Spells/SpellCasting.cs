using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public List<SpellData> knownSpells;
    private List<KeyCode> currentBuffer = new List<KeyCode>();

    // Limits the number of keys the player can type before it clears
    public int maxBufferSize = 5;

    void Update()
    {
        // 1. Detect any key press (A-Z)
        if (Input.anyKeyDown)
        {
            CheckInput();
        }
    }

    void CheckInput()
    {
        // Example: Only listen for Q, W, E, R
        KeyCode[] allowedKeys = { KeyCode.L, KeyCode.K, KeyCode.J };

        foreach (KeyCode k in allowedKeys)
        {
            if (Input.GetKeyDown(k))
            {
                currentBuffer.Add(k);
                Debug.Log("Current Sequence: " + string.Join("->", currentBuffer));

                // 2. Immediately try to find a match
                TryCastSpell();
            }
        }

        // 3. Optional: Clear buffer if it gets too long
        if (currentBuffer.Count > maxBufferSize) currentBuffer.Clear();
    }

    void TryCastSpell()
    {
        foreach (SpellData spell in knownSpells)
        {
            // Compare the buffer to the spell's required sequence
            if (currentBuffer.SequenceEqual(spell.sequence))
            {
                ExecuteSpell(spell);
                currentBuffer.Clear(); // Success!
                return;
            }
        }
    }

    void ExecuteSpell(SpellData spell)
    {
        Debug.Log("Casting: " + spell.spellName);
        Instantiate(spell.prefab, transform.position + transform.forward, transform.rotation);
    }
}
