using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float MaxHP = 100.0f;
    public float Currnet_HP { get; set; }
    public float Move_speed;
    public Status Attack_power;
    public float EXP = 0;
    public int Level = 1;


    //스텔스 스탯 < 적 탐지 트리거 크기 영향  <  스킬레벨 올릴 시 이벤트 발생 < 레벨업 및 스킬UX 
    //  따라서 이후에 추가 예정  
    //Update 에 if문 사용시 비 효율적 일 수 있음 

    private void Awake()
    {
        Currnet_HP = MaxHP;
        Attack_power.SetStat(25);
        Move_speed = 3.5f;
    }
 
    public void TakeDamage(int damage)
    {
        Currnet_HP -= damage;
        UIManager.instance.UpdateHp((int)Currnet_HP);
        damageCheck();
    }
    void damageCheck()
    {
        if (Currnet_HP <= 0)
        {
            //사망이벤트, 게임오버 씬으로 이동
            UIManager.instance.UpdateGameoverUI(true);
        }
    }
}
