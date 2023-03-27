using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    Transform _target;
    
    [SerializeField]
    [Range(0,10)]
   
    float _lerpTime = 5f;

    #endregion

    #region Unity Lifecycle
    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        _velocity = Vector3.zero;

        Vector3 targetPosition_zOffset = new Vector3(_target.position.x, _target.position.y, -10f);
        //Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition_zOffset, _lerpTime * Time.fixedDeltaTime);
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition_zOffset, ref _velocity, _lerpTime * Time.fixedDeltaTime, Mathf.Infinity, Time.fixedDeltaTime);

        transform.position = newPosition; 
    }

    #endregion

    #region Methodes

    #endregion

    #region Private & Protected

    Vector3 _velocity;

    #endregion
}
