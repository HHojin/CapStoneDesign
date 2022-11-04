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


    //���ڽ� ���� < �� Ž�� Ʈ���� ũ�� ����  <  ��ų���� �ø� �� �̺�Ʈ �߻� < ������ �� ��ųUX 
    //  ���� ���Ŀ� �߰� ����  
    //Update �� if�� ���� �� ȿ���� �� �� ���� 

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
            //����̺�Ʈ, ���ӿ��� ������ �̵�
            UIManager.instance.UpdateGameoverUI(true);
        }
    }
}
