using UnityEngine;

public class Enemy_Attack: MonoBehaviour
{
    Transform parent;
   

    void Start()
    {
        parent = this.transform.parent;   
    }

    private void OnTriggerEnter(Collider other) 
    {
      
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("Play Attack motion & stand");

            parent.GetComponent<EnemyAnimationControl>().AttackAnim(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parent.GetComponent<EnemyAnimationControl>().AttackAnim(false);
        }
    }
}
