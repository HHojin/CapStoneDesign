using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public Stat MaxHP;
    public float Current_HP { get; set; }
    public float Move_speed;
    public Stat Attack_power;
    //public Stat Stealth;
    public Stat Armor;
    public float EXP = 0;
    public int Level = 1;

    //스텔스 스탯 < 적 탐지 트리거 크기 영향  <  스킬레벨 올릴 시 이벤트 발생 < 레벨업 및 스킬UX 
    //  따라서 이후에 추가 예정  
    //Update 에 if문 사용시 비 효율적 일 수 있음 

    private void Awake()
    {
        MaxHP.SetStat(100);
        Current_HP = MaxHP.GetStat();
        Move_speed = 3.5f;
        Attack_power.SetStat(25);
        Armor.SetStat(0);
    }
 
    public void TakeDamage(int damage)
    {
        Current_HP -= (damage - Armor.GetStat());
        UIManager.instance.UpdateHp((int)Current_HP);
        damageCheck();
    }
    void damageCheck()
    {
        if (Current_HP <= 0)
        {
            //사망이벤트, 게임오버 씬으로 이동
            UIManager.instance.UpdateGameoverUI(true);
        }
    }
    public void EXPcheck()
    {
        Debug.LogWarning("EXPcheck");
        //레벨 상승 
        if (this.EXP >= 100)//레벨업 필요수치는 배열로? 고정?
        {
            this.Level++;
            this.EXP = 0;
            //UI/UX
            UIManager.instance.ActiveStatUI(true);
        }

    }
}
