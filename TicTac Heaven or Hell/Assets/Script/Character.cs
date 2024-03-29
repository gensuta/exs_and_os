﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "SO/Character", order = 2)]
public class Character : ScriptableObject
{
    public string Name;

    [TextArea(2, 5)]
    public string characterDesc;
    public Sprite characterImg; // should be changed to animator later on! yknow for dif sprites!!

    [Space]
    public string skillName;
    [TextArea(2,5)]
    public string skillDesc;

    [SerializeField] int skillType; // 0 is connectfour, 1 is go...and so on

    public void ActivateSkill()
    {
        switch(skillType)
        {
            case 0:
                StateHandler.Instance.StartConnectFour();
                break;
            case 1:
                break;
        }
    }
}
