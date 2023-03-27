using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerControler : MonoBehaviour
{
    #region Exposed

  
    [SerializeField]
    private IntVariables _beerCollected;

    [SerializeField]
    private int _score = 1;

    #endregion

    #region Unity Lifecycle
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _beerCollected.m_value += _score;
            Destroy(gameObject);
        }
    }

    #endregion

    #region Methodes
    #endregion

    #region Private & Protected
    #endregion
}
