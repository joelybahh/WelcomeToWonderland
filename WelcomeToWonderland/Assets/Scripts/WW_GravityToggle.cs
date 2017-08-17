using NewtonVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_GravityToggle : MonoBehaviour {

    [Header("Gravity Objects")]
    [SerializeField] private List<Rigidbody> m_bodies;

    [Header("Gravity Trigger")]
    [SerializeField] private NVRLever m_control;

    [Header("Gravity Force Offset")]
    [SerializeField] private float m_minForce = 8.0f;
    [SerializeField] private float m_maxForce = 15.0f;

    private bool m_gravityOn = true;
    
	void Start () {
        //m_bodies = new List<Rigidbody>();
        ToggleGravity();
        ToggleGravity();
    }

    void Update() {
        if(m_control.LeverEngaged) {
            ToggleGravity();
        }
    }

    /// <summary>
    /// This function basically toggles gravity for all objects, based on the current 
    /// gravity state.
    /// </summary>
    public void ToggleGravity() {
        float force = Random.Range(m_minForce, m_maxForce);
        m_gravityOn = !m_gravityOn;
        for(int i = 0; i < m_bodies.Count; i++) {
            if (!m_gravityOn) {
                NVRInteractableItem iItem = m_bodies[i].gameObject.GetComponent<NVRInteractableItem>();
                if(iItem != null) iItem.EnableGravityOnDetach = false;
                m_bodies[i].useGravity = false;
                m_bodies[i].AddForce(Vector3.up * force * Time.deltaTime,ForceMode.VelocityChange);
            } else {
                NVRInteractableItem iItem = m_bodies[i].gameObject.GetComponent<NVRInteractableItem>();
                if (iItem != null) iItem.EnableGravityOnDetach = true;
                m_bodies[i].useGravity = true;

            }
        }
    }
}
