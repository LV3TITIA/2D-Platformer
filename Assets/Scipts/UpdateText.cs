using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateText : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private IntVariables _beersCollected;


    #endregion

    #region Unity Lifecycle

    void Awake()
    {
        _label =  GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        _beersCollected.m_value = 0;
    }

    void Update()
    {
        _label.text = _beersCollected.m_value.ToString();
    } 
    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private TextMeshProUGUI _label;
   
    #endregion
}
