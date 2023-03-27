using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleControler : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Sprite[] _collums;

    [SerializeField]
    private SpriteRenderer _image;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _image.sprite = _collums[_nbDammage];
    }

    void Update()
    {
        _image.sprite = _collums[_nbDammage];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            _nbDammage++;
      
        if(_nbDammage >= _collums.Length) 
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private int _nbDammage = 0;
    #endregion
}
