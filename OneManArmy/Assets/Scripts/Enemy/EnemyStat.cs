using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public Stat MaxHP;
    public float Currnet_HP { get; set; }
    public float Move_speed = 5.0f;
    public Stat Attack_power;
    public float EXP = 10; //����� �÷��̾�� �ִ� EXP
    public GameObject[] bodyParts;

    public Transform player;
    PlayerStat player_stat;
    // public int Level = 1;

    //���ڽ� ���� < �� Ž�� Ʈ���� ũ�� ����  <  ��ų���� �ø� �� �̺�Ʈ �߻� < ������ �� ��ųUX 
    //  ĳ���Ϳ� ���ڽ� ����


    private void Awake()
    {
        MaxHP.SetStat(100);
        Currnet_HP = MaxHP.GetStat();
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
            GetComponent<CapsuleCollider>().enabled = false;
            //�÷��̾�� ����ġ �� 
            player_stat.EXP += this.EXP;
            //EXP üũ ���� ������� �� �߻� �̺�Ʈ 
            player_stat.EXPcheck();
            // Debug.LogError("�� ���");
            GetComponent<EnemyAnimationControl>().DeathAnim();
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        //��� �ִϸ��̼� �۵� �� 
        Destroy(this.gameObject, 2.0f);//2�ʵ� ����
    }

}
