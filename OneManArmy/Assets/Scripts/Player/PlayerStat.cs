using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float MaxHP = 100.0f;
    public float Currnet_HP { get; set; }
    public float Move_speed = 50;
    public Status Attack_power;
    public float EXP = 0;
    public int Level = 1;


    private void Awake()
    {
        Currnet_HP = MaxHP;
        Attack_power.SetStat(10);
    }

    public void TakeDamage(int damage)
    {
        Currnet_HP -= damage;
    }
}
