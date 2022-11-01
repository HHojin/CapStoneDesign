using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float MaxHP = 100.0f;
    public float Currnet_HP { get; set; }
    public float Move_speed = 5.0f;
    public Status Attack_power;
    public float EXP = 10; //사망시 플레이어에게 주는 EXP
    public Transform player;
    PlayerStat player_stat;
    // public int Level = 1;

    //스텔스 스탯 < 적 탐지 트리거 크기 영향  <  스킬레벨 올릴 시 이벤트 발생 < 레벨업 및 스킬UX 
    //  캐릭터에 스텔스 생성


    private void Awake()
    {
        Currnet_HP = MaxHP;
        Attack_power.SetStat(15);
         player_stat = player.GetComponent<PlayerStat>();
    }

    public void TakeDamage(int damage)
    {
        Currnet_HP -= damage;
        damageCheck();
    }
    void damageCheck()
    {
        if (Currnet_HP <= 0)
        {
            

            //플레이어에게 경험치 줌 

            player_stat.EXP += this.EXP;
            EXPcheck();
            Debug.LogError("적 사망");
            EnemyDeath();

        }
    }
    //EXP 체크 이후 레벨상승 시 발생 이벤트 
    private void EXPcheck()
    {
       
        //레벨 상승 
        if (player_stat.EXP >= 100)//레벨업 필요수치는 배열로? 고정?
        {
            player_stat.Level++;
            player_stat.EXP = 0;
            //UI/UX
        }

    }

    private void EnemyDeath()
    {
        //사망 애니메이션 작동 후 
     
       
        Destroy(this.gameObject,2.0f);//2초뒤 제거
    }
   
}
