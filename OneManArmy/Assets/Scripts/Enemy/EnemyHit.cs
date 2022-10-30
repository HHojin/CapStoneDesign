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
            Debug.LogError("Enemy's Hit");//적 데미지 처리
            other.GetComponent<PlayerStat>().TakeDamage(Enemy.GetComponent<EnemyStatus>().Attack_power.GetStat());
            Debug.LogError(other.GetComponent<PlayerStat>().Currnet_HP);
        }
    }
}
