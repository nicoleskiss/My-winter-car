using Unity.Burst.Intrinsics;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int i = 0;
    private float speed = 2f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[i].transform.position) < 0.1)
        {
            if(waypoints.Length - 1 > i)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[i] .transform.position, speed * Time.deltaTime);
    }
}
