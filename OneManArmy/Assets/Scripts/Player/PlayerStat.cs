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
        Move_speed = 5.0f;
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
            this.transform.GetChild(0).GetComponent<CapsuleCollider>().enabled = false;

            this.transform.GetChild(0).GetComponent<AnimationControl>().DeathAnim();
            GameManager.instance.GameOver();
        }
    }

    public void EXPcheck()
    {
        Debug.LogWarning("EXPcheck");

        if (this.EXP >= 100)
        {
            this.Level++;
            this.EXP = 0;

            GameManager.instance.LevelUP();
        }
        TraceTriggerUpdate();
    }

    public void TraceTriggerUpdate()
    {
        this.GetComponentInChildren<Enemy_TraceControl>().TriggerSizeUpdate();
    }
}
