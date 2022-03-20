using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillItem : ShopItem
{
    [SerializeField] SubSkill _subSkill;
    public SubSkill subSkill { get { return _subSkill; } }
}
