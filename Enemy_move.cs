using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_move : MonoBehaviour
{
    NavMeshAgent NVagent;
    [SerializeField]
   private GameObject GOplayer;
    // Start is called before the first frame update
    void Start()
    {
         NVagent = this.GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update()
    {
        NVagent.SetDestination(GOplayer.transform.position);
    }
}
