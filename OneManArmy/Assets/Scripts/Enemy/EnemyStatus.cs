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
   // public int Level = 1;

    //스텔스 스탯 < 적 탐지 트리거 크기 영향  <  스킬레벨 올릴 시 이벤트 발생 < 레벨업 및 스킬UX 
    //  따라서 이후에 추가 예정  
    //Update 에 if문 사용시 비 효율적 일 수 있음 

    private void Awake()
    {
        Currnet_HP = MaxHP;
        Attack_power.SetStat(15);
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
            //사망이벤트, 지면 밑으로 내리거나 점점 투명하게 하거나 하는 식, 할당 메모리 반환 (destroy) 

            //플레이어에게 경험치 줌 
            player.GetComponent<PlayerStat>().EXP += this.EXP;
            Debug.LogError("적 사망" + player.GetComponent<PlayerStat>().EXP);
        }
    }
}
