using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAI 
{
    protected ICharacter m_Character = null;
    public ICharacterAI(ICharacter character)
    {
        m_Character = character;
    }
    public virtual void Update()
    {
        
    }
}
