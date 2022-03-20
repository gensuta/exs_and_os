using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBag : MonoBehaviour
{
    [SerializeField] string grabBagName;

    [TextArea(2,5)]
    [SerializeField] string grabBagDescription;

    [SerializeField] int price;

    [SerializeField] bool hasCharacters, hasSubSkills; // can have one or both
    
    public bool HasCharacters { get { return hasCharacters; } }
    public bool HasSubSkills { get { return hasSubSkills; } }

    public string Name { get { return grabBagName; } }




    /*
     * Foolishly thought each item had a percentage ( they don't! )
    public int GetRandomNum(List<float> percentages, List<ShopItem> items) // based off a percentage
    {
        float total = 0;
        float random = Random.value;
        float numToAdd = 0;

        for (int i = 0; i < percentages.Count; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (percentages[i] / total + numToAdd > random)
            {
                return i;
            }
            else
            {
                numToAdd += percentages[i] / total;
            }
        }
        return 0;
    }

    public int GetRandomNum(List<float> percentages, List<CharacterItem> items) // based off a percentage
    {
        float total = 0;
        float random = Random.value;
        float numToAdd = 0;

        for (int i = 0; i < percentages.Count; i++)
        {
            total += percentages[i];
        }

        for(int i = 0; i < items.Count; i++)
        {
            if(percentages[i] /total + numToAdd > random)
            {
                return i;
            }
            else
            {
                numToAdd += percentages[i] / total;
            }
        }
        return 0;
    }


    public int GetRandomNum(List<float> percentages, List<SubSkillItem> items) // based off a percentage
    {
        float total = 0;
        float random = Random.value;
        float numToAdd = 0;

        for (int i = 0; i < percentages.Count; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (percentages[i] / total + numToAdd > random)
            {
                return i;
            }
            else
            {
                numToAdd += percentages[i] / total;
            }
        }
        return 0;
    } */
}
