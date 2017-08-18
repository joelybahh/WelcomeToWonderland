using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_ShowCamera : MonoBehaviour {
    enum WW_CAMERATYPE {
        SIMPLE, DOGDE, PHASABLE
    }
    [SerializeField]
    WW_CAMERATYPE m_type;
    [SerializeField]

    GameObject m_player;
    Rigidbody m_rb;
    public Transform m_center;
    public Vector3 m_axis = Vector3.up;
    public Vector3 m_desiredPosition;
    public float m_radius = 5.0f;
    public float m_radiusSpeed = 0.1f;
    public float m_defaultRotationSpeed = 10.0f;
    public float m_currentRotationSpeed;

    void Start( ) {

        m_center = m_player.transform;
        m_rb = GetComponent<Rigidbody>();
        transform.position = ( transform.position - m_center.position ).normalized * m_radius + m_center.position;
    }

    void Update( ) {
        transform.RotateAround(m_center.position, m_axis, m_currentRotationSpeed * Time.deltaTime);
        m_desiredPosition = ( transform.position - m_center.position ).normalized * m_radius + m_center.position;
        m_desiredPosition.y = 2.0f;
        transform.position = Vector3.MoveTowards(transform.position, m_desiredPosition, Time.deltaTime * m_radiusSpeed);

        m_currentRotationSpeed = m_defaultRotationSpeed;
    }

    private void OnTriggerEnter(Collider other) {
        switch ( m_type ) {
            case WW_CAMERATYPE.SIMPLE:

                break;

            case WW_CAMERATYPE.DOGDE:

                // Check direction of object entering trigger
                // 

                break;

            case WW_CAMERATYPE.PHASABLE:
                Destroy(other.gameObject);
                break;
        }
    }
}
