using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public Stat MaxHP;
    public float Current_HP { get; set; }
    public float Move_speed;
    public Stat Attack_power;
    public Stat Stealth;
    public Stat Armor;
    public float EXP = 0;
    public int Level = 1;



    private void Awake()
    {
        MaxHP.SetStat(100);
        Current_HP = MaxHP.GetStat();
        Move_speed = 3.5f;
        Attack_power.SetStat(25);
        Armor.SetStat(0);
        Stealth.SetStat(100);
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
            //����̺�Ʈ, ���ӿ��� ������ �̵�
            UIManager.instance.UpdateGameoverUI(true);
        }
    }
    public void EXPcheck()
    {
        Debug.LogWarning("EXPcheck");
        //���� ��� 
        if (this.EXP >= 100)//������ �ʿ��ġ�� �迭��? ����?
        {
            this.Level++;
            this.EXP = 0;
            //UI/UX
            UIManager.instance.ActiveStatUI(true);
            
        }
        TraceTriggerUpdate();
    }
    public void TraceTriggerUpdate()
    {
        this.GetComponentInChildren<Enemy_TraceControl>().TriggerSizeUpdate();
      
    }
}
