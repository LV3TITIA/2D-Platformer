using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerControl : MonoBehaviour
{
    #region Exposed

    [SerializeField]

    private Transform _respawnPoint;

    #endregion

    #region Unity Lifecycle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        { 
            collision.transform.position = _respawnPoint.position;
        }
    }
    #endregion

    #region Methodes
    #endregion

    #region Private & Protected
    #endregion
}
