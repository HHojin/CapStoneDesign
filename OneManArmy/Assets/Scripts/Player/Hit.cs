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
            //Debug.LogError("Hit");//利 单固瘤 贸府
            other.GetComponent<EnemyStat>().TakeDamage(transform.parent.parent.GetComponent<PlayerStat>().Attack_power.GetStat());
            //Debug.LogError(other.GetComponent<EnemyStat>().Currnet_HP);
        }
    }
}
