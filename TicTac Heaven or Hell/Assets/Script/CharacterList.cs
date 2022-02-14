using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character List", menuName = "SO/Character List", order = 1)]
public class CharacterList : ScriptableObject
{
    public List<Character> characters;
}
