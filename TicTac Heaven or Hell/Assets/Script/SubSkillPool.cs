using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "subSkillPool", menuName = "SO/SubSkill Pool", order = 0)]
public class SubSkillPool : ScriptableObject
{
    public List<SubSkill> subSkills;
}
