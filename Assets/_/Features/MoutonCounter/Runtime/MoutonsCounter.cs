using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class MoutonsCounter : MonoBehaviour
{
    #region Public Members

    public Vector2Int m_gridSize;

    public Transform m_cell;
    public Transform m_cherifHead;

    public Transform[] m_transforms;
    public Transform[] m_movements;
    public Transform[] m_buildingBlocks;
    public List<int> m_environment = new List<int>();

    #endregion


    #region Unity API

    private void Start()
    {
        int _cellCount = m_gridSize.x * m_gridSize.y;
        int _cellCurrentCount = 0; 

        m_transforms = new Transform[_cellCount];
        m_movements = new Transform[_cellCount];

        for (int x = 0; x < m_gridSize.x; x++)
        {
            for (int z = 0; z < m_gridSize.y; z++)
            {
                m_transforms[_cellCurrentCount] = Instantiate(m_buildingBlocks[m_environment[_cellCurrentCount]], new Vector3(x, 0, z), Quaternion.identity, transform);
                m_transforms[_cellCurrentCount].name = $"Cell: {m_transforms[_cellCurrentCount].position.x}, " +
                                                       $"{m_transforms[_cellCurrentCount].position.y}" +
                                                       $"{m_transforms[_cellCurrentCount].position.z}";
                _cellCurrentCount++;
            }
            
        }       
        int _halfWay = _cellCount / 2;

        m_movements[_halfWay] = Instantiate(m_cherifHead, 
                                            new Vector3(m_transforms[_halfWay].position.x, 1, m_transforms[_halfWay].position.z),
                                            Quaternion.identity,
                                            transform);
    }

    private void Update()
    {
        
    }
    #endregion


    #region Private and Protected
    #endregion
}
