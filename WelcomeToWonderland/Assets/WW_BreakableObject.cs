﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW_BreakableObject : MonoBehaviour {

    [SerializeField] GameObject m_remains;
    private void Update( ) {


        if ( Input.GetKey(KeyCode.Space )) {
            Instantiate(m_remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
