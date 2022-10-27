using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{    
        private int baseStat;

    public void SetStat(int stat)
    {
        baseStat = stat;
    }
        public int GetStat()
        {
            return baseStat;
        } 
}
