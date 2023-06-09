using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFController : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    Transform _startPoint;

    [SerializeField]
    Transform _endPoint;

    [SerializeField]
    float _timeToReach;


    #endregion

    #region Unity Lifecycle
    void Start()
    {
        transform.position = _startPoint.position;

    }

    void Update()
    {
        if (_IsForward)
        {
            _timerMovement += Time.deltaTime;
            if(_timerMovement >= _timeToReach ) 
            {
                _IsForward= false;
            }
        }
        else
        {
            _timerMovement -= Time.deltaTime;
            if(_timerMovement <= 0f)
            {
                _IsForward = true;
            }
        }
         
        Vector3 newposition = Vector3.Lerp(_startPoint.position, _endPoint.position, _timerMovement / _timeToReach);

        transform.position = newposition;
    }
    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private float _timerMovement;
    private bool _IsForward = true;

    #endregion
}
