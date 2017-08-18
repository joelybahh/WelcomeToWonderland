using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WW_BrokenRobot : MonoBehaviour {

    [Header("Movement Settings")]
    [SerializeField] private float m_speed = 15.0f;
    [SerializeField] private float m_bounceBackSpeed = 10.0f;

    [Header("Direction Overrides")]
    [Tooltip("Utilizes the forward vector of a custom transform defined by you.")]
    [SerializeField] private Transform m_newDir = null;

    private Rigidbody m_rbRef = null;

    private bool m_beingHeld = false;

    public bool BeingHeld { get { return m_beingHeld; } set { BeingHeld = value; } }

	void Start () {
        m_rbRef = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        if (!m_beingHeld && m_rbRef.velocity.y < 0.1f) {
            if (m_newDir != null) m_rbRef.AddForce(m_newDir.forward * m_speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            else m_rbRef.AddForce(transform.forward * m_speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
	}

    void OnCollisionEnter(Collision other) {
        
        if (m_beingHeld || m_rbRef.velocity.y > 0.1f) return;
        if (other.transform.tag == "Wall") {
            if (m_newDir != null) m_rbRef.AddForce(-m_newDir.forward * m_bounceBackSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            else m_rbRef.AddForce(-transform.forward * m_bounceBackSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    public void SetBeingHeld(bool a_value) {
        m_beingHeld = a_value;
    }
}
