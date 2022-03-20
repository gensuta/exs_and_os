using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{

    [SerializeField] List<ShopItem> allItems;

    public List<ShopItem> AllItems { get { return allItems; } }

    [SerializeField] GrabBag characterbag, subSkillBag, theBigOne; // the big one has both

    List<CharacterItem> characterItems;
    List<SubSkillItem> subSkillItems;


    [SerializeField] Player player; // need a better way to get the player maybe?? actually since ths shop has one player at a time this is fine


    // Start is called before the first frame update
    void Start()
    {
        characterItems = new List<CharacterItem>();
        subSkillItems = new List<SubSkillItem>();

        foreach(var item in allItems)
        {
            if(item is CharacterItem)
            {
                characterItems.Add((CharacterItem)item);
            }

            if(item is SubSkillItem)
            {
                subSkillItems.Add((SubSkillItem)item);
            }
        }

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //for testing purposes!!!

           OpenGrabBag(theBigOne);


        }
    }

    public void OpenGrabBag(GrabBag g)
    {
        Debug.Log("<color=green> Now opening..." +g.Name + "</color>");
        //we don't know how many items are in the grab bag so lets say 4
        for (int i = 0; i < 4; i++)
        {
            bool isLast = false;
            if(i == 3)
            {
                isLast = true;
            }

            GrabRandomItem(g,isLast);
        }
    }


    public void PurchaseItem(Currency currency, ShopItem item, Player player)
    {
        if(item.GetPrice() > currency.amount)
        {
            // INSUFFICIENT FUUUUUNDS!!
        }
        else
        {
            currency.UseCurrency(item.GetPrice());
            AddItemtoInventory(item);  
        }
    }


    void AddItemtoInventory(ShopItem item)
    {
        if (item is CharacterItem)
        {
            CharacterItem i = (CharacterItem)item;
            player.inventory.unlockedCharacters.Add(i.character);
        }
        else
        {
            SubSkillItem i = (SubSkillItem)item;
            player.inventory.unlockedSubSkills.Add(i.subSkill);
        }
    }

    public void GrabRandomItem(GrabBag g, bool isLast)
    {
        Debug.Log("Grabbing random item...");
        ShopItem item = GetRandomItem(g,isLast);

        Debug.Log("Grabbed " + item.itemName);

        if (player.HasItem(item))
        {
            Debug.Log("Rerolling...");
            GrabRandomItem(g,isLast); // run the function again until we get an item we don't have
        }
        else
        {
            AddItemtoInventory(item);
            Debug.Log("Adding " + item.itemName + " to the player's inventory!");
        }
    }


    ShopItem GetRandomItem(GrabBag grabBag, bool isLast) // last item if in the big one has a 61.74% of being a character
    {
        int randNum = 0;

        if (grabBag.HasCharacters && !grabBag.HasSubSkills)
        {
            randNum = Random.Range(0,characterItems.Count);
            return characterItems[randNum];
        }

        if (grabBag.HasSubSkills && !grabBag.HasCharacters)
        {
            randNum = Random.Range(0, subSkillItems.Count);
            return subSkillItems[randNum];
        }

        if (grabBag.HasCharacters && grabBag.HasSubSkills)
        {
            if (!isLast)
            {
                randNum = Random.Range(1, 101);
                if (randNum > 20) // 80% chance of getting a subskill
                {
                    randNum = Random.Range(0, subSkillItems.Count);
                    return subSkillItems[randNum];
                }
                else // 20% chance of getting a character
                {
                    randNum = Random.Range(0, characterItems.Count);
                    return characterItems[randNum];
                }
            }
            else
            {
                float n = Random.Range(1f, 101f);

                if (n > 61.74f) // 80% chance of getting a subskill
                {
                    randNum = Random.Range(0, subSkillItems.Count);
                    return subSkillItems[randNum];
                }
                else // 20% chance of getting a character
                {
                    randNum = Random.Range(0, characterItems.Count);
                    return characterItems[randNum];
                }
            }
        }

        return null;
    }
}
