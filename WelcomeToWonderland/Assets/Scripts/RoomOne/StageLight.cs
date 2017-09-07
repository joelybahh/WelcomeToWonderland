﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Puzzles {
    public class StageLight : MonoBehaviour {
        [SerializeField]
        Light m_light;
        [SerializeField]
        bool m_isPowered;
        bool m_isOn;
        [SerializeField]
        public int m_SetId = 0;
        public Light Light
        {
            get { return m_light; }
            set { m_light = value; }
        }
        /// <summary>
        /// Returns the powered value, on set, also enables the lights based on whether or not it is powered
        /// </summary>
        public bool GetPowered {
            get {
                return m_isPowered;
            }
            set {
                m_isPowered = value;
                if ( m_isPowered && m_isOn) { m_light.enabled = true; } 
                if ( !m_isPowered ) { m_light.enabled = false; }
            }
        }

        private void Awake() {
            m_isPowered = false;
        }


        /// <summary>
        /// Sets the light to either on or off
        /// </summary>
        /// <param name="a_On">Light on or Light off</param>
        public void SetLight( bool a_On ) {
            m_isOn = a_On;
            if (m_isOn) m_SetId = ++LightPuzzle.m_identifier; 
            if ( !m_isOn) m_SetId = --LightPuzzle.m_identifier;
            if (GetPowered) m_light.enabled = a_On;
            else m_light.enabled = false;

            Debug.Log(LightPuzzle.m_identifier);

        }

        /// <summary>
        /// Changes light to red when incorrect
        /// </summary>
        public void Incorrect() {
            m_light.color = Color.red;
        }

        /// <summary>
        /// Changes light to green when correct
        /// </summary>
        public void Correct() {
            m_light.color = Color.green;
        }
    }
}