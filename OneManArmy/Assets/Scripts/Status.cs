using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{    
    [SerializeField]
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
