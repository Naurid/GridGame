using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherifPirate : MonoBehaviour
{
	#region Public Members

	public GameObject Piratery;
    public GameObject CherifREEEEEEE;
    public GameObject CherifNormal;

    #endregion

    #region Unity API

    private void Update()
    {
        if (MoutonsCounter.Instance.m_isPirate)
        {
            Piratery.SetActive(true);
        }
        else
        {
            Piratery.SetActive(false);
        }

        if (MoutonsCounter.Instance.m_isHot)
        {
            CherifREEEEEEE.SetActive(true);
            CherifNormal.SetActive(false);
        }
        else
        {
            CherifNormal.SetActive(true);
            CherifREEEEEEE.SetActive(false);
        }
    }
    #endregion
}
