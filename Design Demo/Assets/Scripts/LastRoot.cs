using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastRoot 
{
    public int hp;
    public int maxHp;
    public GameObject last;
    public Slider slider;
    TowerDefenceGame game;
    public LastRoot(TowerDefenceGame _game)
    {
        Init();
        game = _game;
    }

    private void Init()
    {
        hp = 10;
        maxHp = 10;
        last = GameObject.Find("RoodWz/End");
        slider = last.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
    }
    public void LessHp(int less)
    {
        hp -= less;
        slider.value = (float)hp / maxHp;
        if (hp<=0)
        {
            game.Finish();
        }
    }
    
}
