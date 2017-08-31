using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Movement {
    public class HeightChange : MonoBehaviour {

        public Transform m_rigRef;

        public float m_distanceThreshold;
        private float m_currentHeight;

        void Start() {
           m_currentHeight = 0;
        }
        
        void FixedUpdate() {
            // Get Current Height from the distance from the head to ground

            // if the CurrentHeight is greater than the raycast distance + threshold
                // Step the player up
            // else if the CurrentHeight is less than the raycast distance - threshold
                // Step the player down
        }
    }
}
