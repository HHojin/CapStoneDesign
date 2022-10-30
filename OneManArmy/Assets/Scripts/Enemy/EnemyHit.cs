using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
   public Transform Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.LogError("Enemy's Hit");//利 单固瘤 贸府
            other.GetComponent<PlayerStat>().TakeDamage(Enemy.GetComponent<EnemyStatus>().Attack_power.GetStat());
            Debug.LogError(other.GetComponent<PlayerStat>().Currnet_HP);
        }
    }
}
