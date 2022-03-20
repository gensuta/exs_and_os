using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Character chosenCharacter; // for the current battle
    public List<SubSkill> chosenSubSkills; // should be only 3
    
    
    bool skillCurrentlyActive;
    SubSkill currentActiveSkill;

    public Inventory inventory;

    public static int skillsChosen;

    public static Player Instance;


    // TODO: These actions should maybe be moved??????
    public event Action<int>  OnColumnErased,OnRowErased;
    public event Action<int, bool> OnColumnShift, OnRowShift;
    public event Action<bool> OnBoardRotated;

    public Currency currency;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(this != Instance) // TODO: what if we have multiple players? Need to figure out how to handle this
        {
            Destroy(this.gameObject);
        }

        GameHandler.OnNewTurn += GameHandler_OnNewTurn;
        SubSkillUI.OnAdded += SubSkillUI_OnAdded;
        SubSkillUI.OnRemoved += SubSkillUI_OnRemoved;
    }


    public bool HasItem(ShopItem item)
    {
        if (item is CharacterItem)
        {
            CharacterItem i = (CharacterItem)item;
            if (inventory.unlockedCharacters.Contains(i.character))
            {
                return true;
            }
        }
        else
        {
            SubSkillItem i = (SubSkillItem)item;
            if (inventory.unlockedSubSkills.Contains(i.subSkill))
            {
                return true;
            }
        }

        return false;
    }

    private void Update()
    {

        // The below is jsut for testing purposes but it would be helpful if in the tileui object if we click and it 
        // only clears until we deactivate the skill ( and also just go to the next turn duhhh )
        // TODO: WE NEED ACTUAL UI TO KNOW WHICH COLUMN/ROW IS AFFECTED!!!
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnBoardRotated?.Invoke(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnRowShift?.Invoke(2, true);
        }
    }

    private void SubSkillUI_OnRemoved(SubSkill obj)
    {
       skillsChosen--;
       chosenSubSkills.Remove(obj);
    }

    private void SubSkillUI_OnAdded(SubSkill obj)
    {
        skillsChosen++;
        chosenSubSkills.Add(obj);
    }

    private void OnDisable()
    {
        GameHandler.OnNewTurn -= GameHandler_OnNewTurn;
        SubSkillUI.OnAdded -= SubSkillUI_OnAdded;
        SubSkillUI.OnRemoved -= SubSkillUI_OnRemoved;
    }



    private void GameHandler_OnNewTurn()
    {
       if(skillCurrentlyActive)
        {
            currentActiveSkill.turnsActive++;

            if(currentActiveSkill.turnsActive >= currentActiveSkill.getTurnsTillDeactivation() || currentActiveSkill.getTurnsTillDeactivation() == 0)
            {
                currentActiveSkill.Deactivate();
            }
            currentActiveSkill = null;
            skillCurrentlyActive = false;
        }
    }


    public void ActivateCharacterSkill()
    {

    }

    public void ActivateSubSkill(int n) 
    {
        if (skillCurrentlyActive) return;

        chosenSubSkills[n].Activate();
        currentActiveSkill = chosenSubSkills[n];
        skillCurrentlyActive = true;
    }


}
