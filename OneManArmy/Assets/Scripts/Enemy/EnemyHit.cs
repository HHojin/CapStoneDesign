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
            Debug.LogWarning("Enemy's Hit");//�� ������ ó��
            other.GetComponent<PlayerStat>().TakeDamage(Enemy.GetComponent<EnemyStatus>().Attack_power.GetStat());
            Debug.LogWarning(other.GetComponent<PlayerStat>().Currnet_HP);
        }
    }
}
