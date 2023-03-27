using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =("new IntaVariable"), menuName =("Variable/IntVariable"))]
public class IntVariables : ScriptableObject
{
    #region Exposed

    public int m_value = 0; 
    
    #endregion
} 
