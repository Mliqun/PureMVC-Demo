using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderSystem 
{
    private int m_GameObjectID = 0;
    public void Construct(ICharacterBuilder builder)
    {
        builder.LoadAsset(m_GameObjectID);
        builder.AddBullet();
        builder.SetCharacterAttr();
        builder.AddAI();
    }
}
