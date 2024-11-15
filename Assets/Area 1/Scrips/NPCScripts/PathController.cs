using System.Collections.Generic;
using Area_1.Scrips.WaypointScripts;
using UnityEngine;

namespace Area_1.Scrips.NPCScripts
{
    public class PathController : MonoBehaviour
    {
        [SerializeField] private PathManager pathManager;
        
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;

        [SerializeField] private Animator animator;

        [SerializeField] private bool idleOnCollide;

        private bool _collided;

        private bool _isWalking;

        private List<Waypoint> _thePath;
        private Waypoint _target;

        private void Start()
        {
            _isWalking = true;
            // animator.SetBool("isWalking", _isWalking);
            
            _thePath = pathManager.GetPath();
            if (_thePath != null && _thePath.Count > 0)
            {
                // set starting target to the first waypoint
                _target = _thePath[0];
            }
        }

        private void RotateTowardsTarget()
        {
            float stepSize = rotateSpeed * Time.deltaTime;

            Vector3 targetDir = _target.GetPos() - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 
                0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        private void MoveForward()
        {
            float stepSize = Time.deltaTime * moveSpeed;
            float distanceToTarget = Vector3.Distance(transform.position, _target.GetPos());
            if (distanceToTarget < stepSize)
            {
                // we will overshoot the target
                // so we should do something smarter here
                return;
            }
            // take a step forward
            transform.Translate(Vector3.forward * stepSize);
        }

        private void Update()
        {
            /*if (Input.anyKeyDown && !(_collided && idleOnCollide))
            {
                // toggle if any key is pressed
                _isWalking = !_isWalking;
                // animator.SetBool("isWalking", _isWalking);
            }*/
            
            if (_isWalking)
            {
            }
            
            RotateTowardsTarget();
            MoveForward();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!idleOnCollide)
            {
                _target = pathManager.GetNextTarget();
                animator.SetTrigger("change");
            }
            else
            {
                _collided = true;
                _isWalking = false;
                // animator.SetBool("isWalking", _isWalking);
            }
        }
    }
}
