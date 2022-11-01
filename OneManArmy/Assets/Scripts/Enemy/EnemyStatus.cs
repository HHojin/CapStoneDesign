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
    public float EXP = 10; //����� �÷��̾�� �ִ� EXP
    public Transform player;
    PlayerStat player_stat;
    // public int Level = 1;

    //���ڽ� ���� < �� Ž�� Ʈ���� ũ�� ����  <  ��ų���� �ø� �� �̺�Ʈ �߻� < ������ �� ��ųUX 
    //  ĳ���Ϳ� ���ڽ� ����


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
            

            //�÷��̾�� ����ġ �� 

            player_stat.EXP += this.EXP;
            EXPcheck();
            Debug.LogError("�� ���");
            EnemyDeath();

        }
    }
    //EXP üũ ���� ������� �� �߻� �̺�Ʈ 
    private void EXPcheck()
    {
       
        //���� ��� 
        if (player_stat.EXP >= 100)//������ �ʿ��ġ�� �迭��? ����?
        {
            player_stat.Level++;
            player_stat.EXP = 0;
            //UI/UX
        }

    }

    private void EnemyDeath()
    {
        //��� �ִϸ��̼� �۵� �� 
     
       
        Destroy(this.gameObject,2.0f);//2�ʵ� ����
    }
   
}
