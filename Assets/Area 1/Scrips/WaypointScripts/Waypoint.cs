using UnityEngine;

namespace Area_1.Scrips.WaypointScripts
{
    [System.Serializable]
    public class Waypoint
    {

        [SerializeField] private Vector3 pos;

        public void SetPos(Vector3 newPos)
        {
            pos = newPos;
        }

        public Vector3 GetPos()
        {
            return pos;
        }

        public Waypoint()
        {
            pos = new Vector3(0, 0, 0);
        }

    }
}
