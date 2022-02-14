using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character chosenCharacter; // for the current battle
    public List<SubSkill> chosenSubSkills; // should be only 3
    bool skillCurrentlyActive;
    SubSkill currentActiveSkill;

    public Inventory inventory;

    public static int skillsChosen;

    private void OnEnable()
    {
        GameHandler.OnNewTurn += GameHandler_OnNewTurn;
        SubSkillUI.OnAdded += SubSkillUI_OnAdded;
        SubSkillUI.OnRemoved += SubSkillUI_OnRemoved;
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

            if(currentActiveSkill.turnsActive == currentActiveSkill.getTurnsTillDeactivation() || currentActiveSkill.getTurnsTillDeactivation() == 0)
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

    public void ActivateSubSkill(int n) // one activated at a time
    {
        if (skillCurrentlyActive) return;

        chosenSubSkills[n].Activate();
        currentActiveSkill = chosenSubSkills[n];
    }


}
