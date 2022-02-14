using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterManager : MonoBehaviour // TODO : Look at how subskillmanager works and go from there
{
    [SerializeField] Image characterImg;
    [SerializeField] TextMeshProUGUI characterName, skillDesc,skillName;

    [SerializeField] Player player;
    int index;

    private void Awake()
    {
        DisplayCharacter(player.inventory.unlockedCharacters[index]);
    }

    public void NextCharacter()
    {
        if(index < player.inventory.unlockedCharacters.Count - 1)
        {
            index++;
          
        }
        else
        {
            index = 0;
        }

        DisplayCharacter(player.inventory.unlockedCharacters[index]);
    }

    public void PrevCharacter()
    {
        if (index > 0)
        {
            index--;
        }
        else
        {
            index = player.inventory.unlockedCharacters.Count - 1;
        }

        DisplayCharacter(player.inventory.unlockedCharacters[index]);

    }

    public void DisplayCharacter(Character c)
    {
        player.chosenCharacter = c;
        characterImg.sprite = c.characterImg;
        characterName.text = c.Name;
        skillName.text = c.skillName;
        skillDesc.text = c.skillDesc;
    }
}
