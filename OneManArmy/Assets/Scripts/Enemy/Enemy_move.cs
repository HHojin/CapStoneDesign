using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_move : MonoBehaviour
{

    NavMeshAgent NVagent;
    
    public GameObject GOplayer = null;
   public bool trace = false;

    private void Awake()
    {
        GOplayer = GameObject.Find("Main_player");
       
    }

    // Start is called before the first frame update
    void Start()
    {
         NVagent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trace)
        {
            NVagent.SetDestination(GOplayer.transform.position);
        }
       
    }
    

    
}
