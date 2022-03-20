using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem : ShopItem
{  
    [SerializeField] Character _character;

    public Character character { get { return _character; } }
}
