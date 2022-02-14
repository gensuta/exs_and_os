using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadoutSkillUI : MonoBehaviour
{
    public SubSkill mySkill;
    [SerializeField] Image img;
    [SerializeField] SubSkillManager subSkillManager;

    private void Awake()
    {
        img.color = Color.grey;
    }

    bool isEmpty
    {
        get
        {
            if (mySkill == null) return true;
            else return false;
        }
    }

    public void OnClick() // if we click on our lil button
    {
        subSkillManager.OpenInventory();
    }

    public void OnHover()
    {
        if(!isEmpty)
        {
            Debug.Log("skill stuff!!");
        }
    }

    public void ReceiveSkill(SubSkill newSkill)
    {
        img.color = Color.white;

        mySkill = newSkill;
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();

        text.text = mySkill.subSkillName;

        if (newSkill.icon != null) { img.sprite = newSkill.icon; }


    }

    public void Clear()
    {
        img.color = Color.grey;
        mySkill = null;
    }
}
