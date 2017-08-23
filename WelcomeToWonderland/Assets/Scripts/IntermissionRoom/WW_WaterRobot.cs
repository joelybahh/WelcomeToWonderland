﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Author: Joel Gabriel
/// Description: he AI for the water robot that patrols the intermission room
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class WW_WaterRobot : MonoBehaviour {

    [SerializeField]
    public enum ePathingBehaviour {
        LOOPING,
        PING_PONG,
        STOP_AT_END
    }

    #region Serialized Variables

    [Header("Movement Settings")]
    [SerializeField] float m_moveSpeed = 2.0f;
    [SerializeField] float m_nextNodeDelay = 0.0f;

    [Header("Pathfinding Behaviour Settings")]
    [SerializeField] ePathingBehaviour m_pathingBehaviour = ePathingBehaviour.LOOPING;

    [Header("AI Manager Override")]
    [SerializeField] WW_AIPathManager m_pathOverride;

    #endregion

    #region Private Variables

    private NavMeshAgent      m_agent           = null;
    private Transform         m_currentTarget   = null;
    private WW_AIPathManager  m_path            = null;
    private int               m_pathIndex       = 0;
    private bool              m_movingForward   = true;
    private bool              m_goalNodeReached = false;
    private bool              m_isStoppedAtEnd  = false;

    #endregion

    void Start () {
        m_agent = GetComponent<NavMeshAgent>();

        if ( m_pathOverride == null ) m_path = GameObject.Find("MainWaypoints").GetComponent<WW_AIPathManager>(); // FIXME: SLOW, pass by reference prefered!
        else m_path = m_pathOverride;

        m_currentTarget = m_path.GetNearestWaypoint(transform.position, out m_pathIndex);
        m_agent.SetDestination(m_currentTarget.position);
        m_agent.speed = m_moveSpeed;
    }
    
	void Update () {
        if ( m_isStoppedAtEnd ) return;
		switch(m_pathingBehaviour) {
            case ePathingBehaviour.LOOPING:     UpdateLooping();    break;
            case ePathingBehaviour.PING_PONG:   UpdatePingPong();   break;            
            case ePathingBehaviour.STOP_AT_END: UpdateStopAtEnd();  break;
        }
	}

    /// <summary>
    /// Updates the logic for LOOPING behaviour
    /// </summary>
    private void UpdateLooping() {
        if ( Vector3.Distance(transform.position, m_agent.destination) <= 1 ) {
            if ( m_nextNodeDelay <= 0 ) {
                Vector3 newTarget = m_path.GetNextWaypoint(ref m_pathIndex, m_pathingBehaviour, ref m_movingForward).position;
                m_agent.SetDestination(newTarget);
            } else {
                DelayUpdatingWaypoint();
            }
        }
    }
   
    /// <summary>
    /// Updates the logic for PING_PONG behaviour
    /// </summary>
    private void UpdatePingPong() {
        if ( Vector3.Distance(transform.position, m_agent.destination) <= 1 ) {
            if ( m_nextNodeDelay <= 0 ) {
                Vector3 newTarget = m_path.GetNextWaypoint(ref m_pathIndex, m_pathingBehaviour, ref m_movingForward).position;
                m_agent.SetDestination(newTarget);
            } else {
                DelayUpdatingWaypoint();
            }
        }
    }

    /// <summary>
    /// Updates the logic for STOP_AT_END behaviour
    /// </summary>
    private void UpdateStopAtEnd() {
        // if we have no current destination          
        if ( Vector3.Distance(transform.position, m_agent.destination) <= 1 ) {
            if ( m_nextNodeDelay <= 0 ) {
                // get a reference to the next waypoint
                Transform newTarget = m_path.GetNextWaypoint(ref m_pathIndex, m_pathingBehaviour, ref m_movingForward);
                // if that reference happens to be null, we reached the end, so STOP_AT_END and return
                if ( newTarget == null ) { return; m_isStoppedAtEnd = true; }
                // otherwise simply setup its new destination
                else {
                    m_agent.SetDestination(newTarget.position);
                }
            } else {
                DelayUpdatingWaypoint(true);
            }
        }
    }

    /// <summary>
    /// This coroutine simply delays the time between moving on to the next waypoint.
    /// </summary>
    /// <param name="a_isStopAtEnd">whether or not you are in the StopAtEnd behaviour</param>
    /// <returns></returns>
    private IEnumerator DelayUpdatingWaypoint(bool a_isStopAtEnd = false) {
        if ( !a_isStopAtEnd ) {
            yield return new WaitForSeconds(m_nextNodeDelay);
            Vector3 newTarget = m_path.GetNextWaypoint(ref m_pathIndex, m_pathingBehaviour, ref m_movingForward).position;
            m_agent.SetDestination(newTarget);
        } else {
            yield return new WaitForSeconds(m_nextNodeDelay);
            Transform newTarget = m_path.GetNextWaypoint(ref m_pathIndex, m_pathingBehaviour, ref m_movingForward);
            if ( newTarget == null ) yield return null;
            // otherwise simply setup its new destination
            else {
                m_agent.SetDestination(newTarget.position);
            }
        }
    }

    /// <summary>
    /// Simply restarts our AI if it has reached the stop point (fyi, it only will work on STOP_AT_END behaviour.)
    /// </summary>
    public void ResetStoppedAI() {
        if ( !m_isStoppedAtEnd ) return;    // clearly the robot isnt off, dont continue with this function call

        m_isStoppedAtEnd = false;
        m_agent.SetDestination(m_path.GetWaypointPositionFromIndex(1));
    }
}
