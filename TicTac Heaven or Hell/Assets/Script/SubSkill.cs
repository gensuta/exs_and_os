using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[CreateAssetMenu(fileName = "subSkill", menuName = "SO/subSkill",order = 0)]
public class SubSkill : ScriptableObject
{
    public string subSkillName;

    [TextArea(2,5)]
    public string description;


    public Sprite icon;
    [Space]

    public int turnsActive;
    [SerializeField] int turnsTillDeactivation;
    [SerializeField] int Xamount;

    List<Tile> tiles;

    [Space]
    [Header("Optional enums")]
    [Tooltip("None of the below are needed! But can be used of course")]
    public SkillType skillType;
    public TileAmount tileAmount;
    public ShiftType shiftType;

    public enum SkillType { Movement, Switch, Erase, Block};

    public enum TileAmount { None, Row, Column, Single, X, Random}

    public enum ShiftType { None, Horizontally, Vertically, ClockWise, CounterClockWise}

    public Tile storedTile;


    public int getTurnsTillDeactivation()
    {
        return turnsTillDeactivation;
    }

    public void Activate()
    {
        switch(skillType)
        {
            case SkillType.Block: // block a space, block all spaces except x spaces
                ActivateBlockSkill();
                break;
            case SkillType.Movement:
                ActivateMoveSkill();
                break;
            case SkillType.Switch:
                ActivateSwitchSkill();
                break;
            case SkillType.Erase:
                ActivateEraseSkill();
                break;
        }
    }


    void ActivateBlockSkill()
    {
        switch (tileAmount)
        {
            case TileAmount.Column:
                break;
            case TileAmount.Random:
                break;
            case TileAmount.Row:
                break;
            case TileAmount.Single:
                break;
            case TileAmount.X:
                break;
        }
    }

    void ActivateMoveSkill()
    {
        switch (shiftType)
        {
            case ShiftType.Horizontally:
                break;
            case ShiftType.Vertically:
                break;
            case ShiftType.ClockWise:
                break;
            case ShiftType.CounterClockWise:
                break;
        }
    }

    void ActivateEraseSkill()
    {
        switch (tileAmount)
        {
            case TileAmount.Column:
                break;
            case TileAmount.Random:
                break;
            case TileAmount.Row:
                break;
            case TileAmount.Single:
                break;
            case TileAmount.X:
                break;
        }
    }

     void ActivateSwitchSkill()
    {
        GameHandler.Instance.ToggleSwitch();
    }


    public void Deactivate()
    {
        switch (skillType)
        {
            case SkillType.Block:
                DeActivateBlockSkill();
                break;
            case SkillType.Movement:
                DeActivateMoveSkill();
                break;
            case SkillType.Switch:
                DeActivateSwitchSkill();
                break;
            case SkillType.Erase:
                DeActivateEraseSkill();
                break;
        }
    }

     void DeActivateBlockSkill()
    {
        switch (tileAmount)
        {
            case TileAmount.Column:
                break;
            case TileAmount.Random:
                break;
            case TileAmount.Row:
                break;
            case TileAmount.Single:
                break;
            case TileAmount.X:
                break;
        }
    }

     void DeActivateMoveSkill()
    {
        switch (shiftType)
        {
            case ShiftType.Horizontally:
                break;
            case ShiftType.Vertically:
                break;
            case ShiftType.ClockWise:
                break;
            case ShiftType.CounterClockWise:
                break;
        }
    }

     void DeActivateEraseSkill()
    {
        switch (tileAmount)
        {
            case TileAmount.Column:
                break;
            case TileAmount.Random:
                break;
            case TileAmount.Row:
                break;
            case TileAmount.Single:
                break;
            case TileAmount.X:
                break;
        }
    }

     void DeActivateSwitchSkill()
    {
        GameHandler.Instance.ToggleSwitch();
    }
}
