﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubSkillManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryObject; // THIS IS A PANEL!!!
    [SerializeField] Player player;
    [SerializeField] GameObject subSkillPrefab, subSkillPanel;
    [SerializeField] LoadoutSkillUI[] loadoutSkills;

    bool hasSpawnedSubskills;

    public void OpenInventory()
    {
        InventoryObject.SetActive(true);
        DisplaySubSkills();
    }

    public void DisplaySubSkills()
    {
        if (hasSpawnedSubskills) return;

        foreach(SubSkill s in player.inventory.unlockedSubSkills)
        {
            GameObject g = Instantiate(subSkillPrefab, subSkillPanel.transform);

            SubSkillUI _s = g.GetComponent<SubSkillUI>();
            _s.mySkill = s;

            if (s.icon != null)
            {
                g.GetComponent<Image>().sprite = s.icon;
            }

            g.GetComponentInChildren<TextMeshProUGUI>().text = s.subSkillName;
        }

        hasSpawnedSubskills = true;
    }

    public void CloseInventory()
    {
        InventoryObject.SetActive(false);

        foreach(LoadoutSkillUI l in loadoutSkills)
        {
            l.Clear();
        }

        for (int i = 0; i < player.chosenSubSkills.Count; i++)
        {
            loadoutSkills[i].ReceiveSkill(player.chosenSubSkills[i]); // updating the subskill we seen in our load out screen!
        }
    }


}
