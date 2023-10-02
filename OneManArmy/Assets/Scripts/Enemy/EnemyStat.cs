using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public Stat MaxHP;
    public float Currnet_HP { get; set; }
    public float Move_speed;
    public Stat Attack_power;
    public float EXP = 10;
    public Vector3 Pos;

    public Transform player;
    PlayerStat player_stat;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.parent;
        MaxHP.SetStat(100);
        Currnet_HP = MaxHP.GetStat();
        Attack_power.SetStat(15);
        Move_speed = 4.7f;
        Pos = this.transform.position;

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
            GetComponent<BoxCollider>().enabled = false;

            player_stat.EXP += this.EXP;

            player_stat.EXPcheck();

            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        GetComponent<EnemyAnimationControl>().DeathAnim();
        Destroy(this.gameObject, 2.0f);
    }

    public void ResetPosition()
    {
        this.transform.position = Pos;
    }
}