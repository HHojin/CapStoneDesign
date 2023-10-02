using UnityEngine;

public class Hit : MonoBehaviour
{
    GameObject mainPlayer;

    private void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        mainPlayer = GameObject.Find("Main_player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            //Debug.LogError("Hit");
            other.GetComponent<EnemyStat>().TakeDamage(mainPlayer.transform.GetComponent<PlayerStat>().Attack_power.GetStat());
            //Debug.LogError(other.GetComponent<EnemyStat>().Currnet_HP);
        }
    }
}