using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoball : MonoBehaviour {

    [SerializeField] private float m_spinSpeed = 10f;
    [SerializeField] private Vector3 m_axis;

	// Update is called once per frame
	void Update () {
        transform.Rotate(m_axis, m_spinSpeed * Time.deltaTime);
	}
}
