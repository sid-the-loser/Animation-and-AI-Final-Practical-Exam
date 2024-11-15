using System;
using UnityEngine;
using UnityEngine.AI;

namespace Area_3.Scripts
{
    public class ClickToMove : MonoBehaviour
    {
        public Animator playerAnimator;
        NavMeshAgent agent;
        
        void Start() {
            agent = GetComponent<NavMeshAgent>();
        }
        
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                    agent.destination = hit.point;
                    // print(hit.point);
                }
            }
        }

        public void TriggerDeath()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                playerAnimator.SetTrigger("attack");
            }
            else if (other.gameObject.CompareTag("Respawn"))
            {
                playerAnimator.SetTrigger("die");
            }
        }
    }
}
