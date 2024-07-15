using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class PlayerStatHandler
{
    StatBase[] stats;

    public PlayerStatHandler()
    {
        stats = new StatBase[Enum.GetNames(typeof(StatSpecies)).Length];
        stats[(int)StatSpecies.LV] = new Stat<int>(StatSpecies.LV, 1);
        stats[(int)StatSpecies.Name] = new Stat<string>(StatSpecies.Name, "");
        stats[(int)StatSpecies.HP] = new Stat<int>(StatSpecies.HP,20);
        stats[(int)StatSpecies.plusHP] = new Stat<int>(StatSpecies.plusHP,0);
        stats[(int)StatSpecies.ATKPower] = new Stat<int>(StatSpecies.ATKPower,5);
        stats[(int)StatSpecies.plusATKPower] = new Stat<int>(StatSpecies.plusATKPower,0);
        stats[(int)StatSpecies.ATKRate] = new Stat<int>(StatSpecies.ATKRate,3);
        stats[(int)StatSpecies.plusATKRate] = new Stat<int>(StatSpecies.plusATKRate,0);
        stats[(int)StatSpecies.Defence] = new Stat<int>(StatSpecies.Defence,3);
        stats[(int)StatSpecies.plusDefence] = new Stat<int>(StatSpecies.plusDefence,0);
        stats[(int)StatSpecies.Speed] = new Stat<int>(StatSpecies.Speed,1);
        stats[(int)StatSpecies.plusSpeed] = new Stat<int>(StatSpecies.plusSpeed,0);
        stats[(int)StatSpecies.Exp] = new Stat<int>(StatSpecies.Exp,10);
        stats[(int)StatSpecies.MaxExp] = new Stat<int>(StatSpecies.MaxExp,20);
    }
    //public PlayerStatHandler( save file )

    public Stat<T> GetStat<T>(StatSpecies species)
    {
        return stats[(int)species] as Stat<T>;
    }

    public void AddExp(int exp)
    {
        GetStat<int>(StatSpecies.Exp).AddValue(exp);
        LevelUp(1);
    }

    // for debug, the access modified to `public`
    // after the debugging procedure, turn it to private
    public void LevelUp(int val = 1)
    {
        int curExp = GetStat<int>(StatSpecies.Exp).value;
        int maxExp = GetStat<int>(StatSpecies.MaxExp).value;
        if (curExp >= maxExp)
        {
            GetStat<int>(StatSpecies.LV).AddValue(val);
            GetStat<int>(StatSpecies.Exp).AddValue(-curExp);
            int newMax = GetStat<int>(StatSpecies.LV).value*10;
            GetStat<int>(StatSpecies.MaxExp).AddValue(-maxExp + newMax);
        }
    }
}

public class StatBase
{
    public StatSpecies species { get; protected set; }
    
}
public class Stat<T> : StatBase
{
    public T value { get; private set; }

    public Stat(StatSpecies species, T value)
    {
        this.species = species;
        this.value = value;
    }

    public void AddValue(T value) => this.value = value;

}