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
   // public int Level = 1;

    //���ڽ� ���� < �� Ž�� Ʈ���� ũ�� ����  <  ��ų���� �ø� �� �̺�Ʈ �߻� < ������ �� ��ųUX 
    //  ���� ���Ŀ� �߰� ����  
    //Update �� if�� ���� �� ȿ���� �� �� ���� 

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
            //����̺�Ʈ, ���� ������ �����ų� ���� �����ϰ� �ϰų� �ϴ� ��, �Ҵ� �޸� ��ȯ (destroy) 

            //�÷��̾�� ����ġ �� 
            player.GetComponent<PlayerStat>().EXP += this.EXP;
            Debug.LogError("�� ���" + player.GetComponent<PlayerStat>().EXP);
        }
    }
}
