using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
   public Transform Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("Enemy's Hit");//적 데미지 처리
            other.transform.parent.GetComponent<PlayerStat>().TakeDamage(Enemy.GetComponent<EnemyStat>().Attack_power.GetStat());
            Debug.LogWarning(other.transform.parent.GetComponent<PlayerStat>().Current_HP);
        }
    }
}
