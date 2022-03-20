using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    Player player;

    [SerializeField] Image characterImg, topCharImg; // normal character img is for activating the character's skill!
    [SerializeField] Image[] subskillImgs; // all should be off by default

    void Start()
    {
        player = Player.Instance;
        LoadInfo();
    }

    void LoadInfo()
    {
        LoadCharacter();
        LoadSubSkills();
    }

    void LoadCharacter()
    {
        characterImg.sprite = player.chosenCharacter.characterImg;
        topCharImg.sprite = player.chosenCharacter.characterImg;
    }

    void LoadSubSkills()
    {
        for (int i = 0; i < player.chosenSubSkills.Count; i++)
        {
            subskillImgs[i].gameObject.SetActive(true);

            if (player.chosenSubSkills[i].icon != null)
            {
                subskillImgs[i].sprite = player.chosenSubSkills[i].icon;
            }


        }
    }

    public void UseCharacterSkill()
    {
        player.chosenCharacter.ActivateSkill();
    }

    public void UseSubSkill(int n)
    {
        player.ActivateSubSkill(n);
    }

}
