using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatHandler
{
    StatBase[] stats;

    public PlayerStatHandler()
    {
        stats = new StatBase[Enum.GetNames(typeof(StatSpecies)).Length];
        stats[(int)StatSpecies.LV] = new StatInt(nameof(StatSpecies.LV), 1);
        stats[(int)StatSpecies.Name] = new StatString(nameof(StatSpecies.Name), "");
        stats[(int)StatSpecies.HP] = new StatInt(nameof(StatSpecies.HP),20);
        stats[(int)StatSpecies.plusHP] = new StatInt(nameof(StatSpecies.plusHP),0);
        stats[(int)StatSpecies.ATKPower] = new StatInt(nameof(StatSpecies.ATKPower),5);
        stats[(int)StatSpecies.plusATKPower] = new StatInt(nameof(StatSpecies.plusATKPower),0);
        stats[(int)StatSpecies.ATKRate] = new StatInt(nameof(StatSpecies.ATKRate),3);
        stats[(int)StatSpecies.plusATKRate] = new StatInt(nameof(StatSpecies.plusATKRate),0);
        stats[(int)StatSpecies.Defence] = new StatInt(nameof(StatSpecies.Defence),3);
        stats[(int)StatSpecies.plusDefence] = new StatInt(nameof(StatSpecies.plusDefence),0);
        stats[(int)StatSpecies.Speed] = new StatInt(nameof(StatSpecies.Speed),1);
        stats[(int)StatSpecies.plusSpeed] = new StatInt(nameof(StatSpecies.plusSpeed),0);
        stats[(int)StatSpecies.Exp] = new StatInt(nameof(StatSpecies.Exp),10);
        stats[(int)StatSpecies.MaxExp] = new StatInt(nameof(StatSpecies.MaxExp),20);
    }
    //public PlayerStatHandler( save file )

    public StatBase GetStat(StatSpecies species)
    {
        return stats[(int)species];
    }

    public void AddExp(int exp)
    {
        GetStat(StatSpecies.Exp).AddValue(exp);
        LevelUp(1);
    }

    // for debug, the access modified to `public`
    // after the debugging procedure, turn it to private
    public void LevelUp(int val = 1)
    {
        int curExp = GetStat(StatSpecies.Exp).GetStatIntValue();
        int maxExp = GetStat(StatSpecies.MaxExp).GetStatIntValue();
        if (curExp >= maxExp)
        {
            GetStat(StatSpecies.LV).AddValue(val);
            GetStat(StatSpecies.Exp).AddValue(-curExp);
            int newMax = GetStat(StatSpecies.LV).GetStatIntValue()*10;
            GetStat(StatSpecies.MaxExp).AddValue(-maxExp + newMax);
        }
    }
}

public abstract class StatBase
{
    public string name { get; protected set; }

    public virtual int GetStatIntValue()
    {
        return 0;
    }

    public virtual string GetStatStringValue()
    {
        return "";
    }

    public abstract void AddValue(int ival = 0, string sval = "");

}
public class StatInt : StatBase
{
    public int value { get; private set; }

    public StatInt(string name, int value)
    {
        this.name = "";
        this.value = value;
    }

    public override int GetStatIntValue()
    {
        return value;
    }

    public override void AddValue(int ival =0, string sval = "")
    {
        value += ival;
    }
}

public class StatString : StatBase
{
    public string value { get; private set; }

    public StatString(string name, string value)
    {
        this.name = name;
        this.value = value;
    }

    public override string GetStatStringValue()
    {
        return value;
    }

    public override void AddValue(int ival = 0, string sval = "")
    {
        value += sval;
    }
}