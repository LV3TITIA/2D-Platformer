using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WaypointMode
{
    LOOP,
    PINGPONG
}

public class PFWayPointController : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Transform[] _waypoint;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _distTolerance;

    [SerializeField]
    private WaypointMode _mode = WaypointMode.LOOP;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        transform.position = _waypoint[0].position;
        _targetWaypoint = 1;

    }

    void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, _waypoint[_targetWaypoint].position, _speed * Time.deltaTime);
        transform.position = newPosition;

        if (Vector3.Distance(transform.position, _waypoint[_targetWaypoint].position) <= _distTolerance)
         {

            //Methode pour faire une Loop
           /* _targetWaypoint++;
            if(_targetWaypoint >= _waypoint.Length) 
            {
                _targetWaypoint = 0;
            }*/


            //Methode pour faire un ping pong
            if (_isForward)
            {
                _targetWaypoint++;
                if (_targetWaypoint >= _waypoint.Length - 1)
                {
                    _isForward = false;
                }
            }
            else
            {
                _targetWaypoint--;
                if (_targetWaypoint <= 0)
                {
                    _isForward = true;
                }
            }
        }

    }
    #endregion

    #region Methodes

    #endregion

    #region Private & Protected

    private int _targetWaypoint;

    private bool _isForward = true;
    #endregion
}
