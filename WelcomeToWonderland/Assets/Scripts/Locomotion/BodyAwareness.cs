﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Movement {
    public class BodyAwareness : MonoBehaviour {

        public Transform m_rigRef;

        public LayerMask m_layerMask;

        public float m_distanceThreshold;
        private float m_currentHeight;

        private Vector3 m_lastGoodStepPoint;
        private Vector3 curPoint;
        
        void Start() {
            m_currentHeight = 0;
        }

        void Update() {
            Ray ray = new Ray(transform.GetChild(0).position, Vector3.down);
            RaycastHit hit;

            if (UnityEngine.Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask)) {
                if (hit.transform.tag == "Teleportable") {
                    curPoint = hit.point;                  

                    if (m_lastGoodStepPoint == Vector3.zero) {
                        m_lastGoodStepPoint = hit.point;
                    }

                    // TOO BIG OF A STEP
                    if (curPoint.y > m_lastGoodStepPoint.y && (curPoint.y - m_lastGoodStepPoint.y) > m_distanceThreshold) {
                        m_rigRef.position = m_lastGoodStepPoint;
                       // m_lastGoodStepPoint = hit.point;
                    } else if (curPoint.y > m_lastGoodStepPoint.y && (curPoint.y - m_lastGoodStepPoint.y) < m_distanceThreshold) {
                        m_lastGoodStepPoint = curPoint;
                    }
                }
            }
        }

        public void SetGoodstep() {
            m_lastGoodStepPoint = m_rigRef.position;
        }
    }
}