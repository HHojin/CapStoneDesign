using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.LogError("Hit");//利 单固瘤 贸府
            other.GetComponent<EnemyStatus>().TakeDamage(transform.parent.GetComponent<PlayerStat>().Attack_power.GetStat());
            Debug.LogError(other.GetComponent<EnemyStatus>().Currnet_HP);

        }
    }
}
