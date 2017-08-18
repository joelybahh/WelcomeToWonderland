using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_WheelOfFortune : MonoBehaviour {

    [Header("Wheel References")]
    [SerializeField] private Transform m_outerRing;
    [SerializeField] private Transform m_middleRing;
    [SerializeField] private Transform m_centerRing;

    [Header("Rotation Bounds")]
    [Range(0, 360)] [SerializeField] private float m_minRot;
    [Range(0, 360)] [SerializeField] private float m_maxRot;

    void Start () {
		
	}
	
	void Update () {
        if (m_outerRing.transform.rotation.z > 360) m_outerRing.transform.rotation = new Quaternion(m_outerRing.transform.rotation.x, m_outerRing.transform.rotation.y, 0, 1);
        else if(m_outerRing.transform.rotation.z <= 0) m_outerRing.transform.rotation = new Quaternion(m_outerRing.transform.rotation.x, m_outerRing.transform.rotation.y, 360, 1);
    }

    private void CheckCorrectAlignment() {
        if(m_outerRing.rotation.z >= m_minRot && m_outerRing.rotation.z <= m_maxRot &&
           m_outerRing.rotation.z >= m_minRot && m_outerRing.rotation.z <= m_maxRot &&
           m_outerRing.rotation.z >= m_minRot && m_outerRing.rotation.z <= m_maxRot) {

        }
    }
}
