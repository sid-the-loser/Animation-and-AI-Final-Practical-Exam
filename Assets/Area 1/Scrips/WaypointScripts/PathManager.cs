using System.Collections.Generic;
using UnityEngine;

namespace Area_1.Scrips.WaypointScripts
{
    public class PathManager : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private List<Waypoint> path;
        [SerializeField] private GameObject prefab;
        
        private List<GameObject> _prefabPoints;
        
        private int _currentPointIndex;

        public List<Waypoint> GetPath()
        {
            if (path == null)
            {
                path = new List<Waypoint>();
            }

            return path;
        }

        public void CreateAddPoint()
        {
            Waypoint go = new Waypoint();
            path.Add(go);
        }

        public Waypoint GetNextTarget()
        {
            int nextPointIndex = (_currentPointIndex + 1) % path.Count;
            _currentPointIndex = nextPointIndex;
            
            return path[nextPointIndex];
        }

        private void Start()
        {
            _prefabPoints = new List<GameObject>();
            // create prefab colliders for the path locations
            foreach (var p in path)
            {
                GameObject go = Instantiate(prefab);
                go.transform.position = p.GetPos();
                _prefabPoints.Add(go);
            }
        }

        private void Update()
        {
            for (int i = 0; i < path.Count; i++)
            {
                Waypoint p = path[i];
                GameObject g = _prefabPoints[i];
                g.transform.position = p.GetPos();
            }
        }
    }
}
