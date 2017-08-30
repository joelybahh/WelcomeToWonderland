using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInSight : MonoBehaviour {

    public Transform m_controllerRef;
    public Transform m_headsetRef;

    public static bool m_controllerInSight = true;
    
	void Start () {
		
	}
    
    void FixedUpdate() {
        Vector3 dir = m_headsetRef.position - m_controllerRef.position;

        Ray ray = new Ray(m_controllerRef.position, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            if(hit.transform.tag != "MainCamera") {
                m_controllerInSight = false;
            } else {
                m_controllerInSight = true;
            }
        }

        Debug.Log(m_controllerInSight);
    }
}
