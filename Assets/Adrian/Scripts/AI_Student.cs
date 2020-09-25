using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(requiredComponent: typeof(NavMeshAgent))]
public class AI_Student : MonoBehaviour
{
    private int currentWaypoint = 0;
    [SerializeField] private NavMeshAgent navAgent;
    private List<Transform> randomWaypoints = new List<Transform>();

    //======================== Alex's messing up ==========
    private Student student;

    //======================================================
    /// <summary>
    /// Checks if the AI has completed pathfinding
    /// </summary>
    private bool PathComplete
    {
        get
        {
            if (!navAgent.pathPending)
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0) return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// Use this function to set the student's destination
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Vector3 target)
    {
        navAgent.SetDestination(target);
    }

    private void Awake()
    {
        student = GameObject.FindObjectOfType<Student>();
    }
    private void Reset()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.stoppingDistance = 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        List<int> randomIndex = new List<int>();
        randomWaypoints = Waypoints.GetWaypoints.OrderBy(x => Random.value).ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        if (PathComplete && !student.IsSelected())
        {
            if (currentWaypoint < randomWaypoints.Count)
            {
                //currentWaypoint++;

                Vector3 deltaToTarget = transform.position - randomWaypoints[currentWaypoint].position;

                if (deltaToTarget.sqrMagnitude < 0.5f && currentWaypoint + 1 < randomWaypoints.Count) currentWaypoint++;

                SetTarget(randomWaypoints[currentWaypoint].position);
            }
        }
    }
}