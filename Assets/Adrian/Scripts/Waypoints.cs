using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    public static List<Transform> GetWaypoints;

    void Awake()
    {

        GetWaypoints = waypoints;
    }
}
