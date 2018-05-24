using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace TowerDefence
{
    public class AIAgent : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent nav;
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if(target)
            {
                nav.SetDestination(target.position);
            }
        }
    }
}