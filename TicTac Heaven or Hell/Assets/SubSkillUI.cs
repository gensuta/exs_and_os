using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SubSkillUI : MonoBehaviour
{
    public SubSkill mySkill;
    [SerializeField] Image img;
    public static event Action<SubSkill> OnAdded, OnRemoved;

    private void Awake()
    {
        img.color = Color.grey;
    }

    public void ToggleSubskill()
    {

        if (img.color != Color.yellow) // equip
        {
            if (Player.skillsChosen < 3)
            {
                img.color = Color.yellow;
                OnAdded?.Invoke(mySkill);
            }
            else
            {
                //TODO: Make this a pop up for the player
                Debug.Log("Inventory ful!!");
            }
        }
        else // unequip
        {
            img.color = Color.grey;
            OnRemoved?.Invoke(mySkill);
        }
    }

}
