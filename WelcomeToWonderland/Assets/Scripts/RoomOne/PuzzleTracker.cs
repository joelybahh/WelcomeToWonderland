using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WW.Puzzles {
    public class PuzzleTracker : MonoBehaviour {

        [Header("Timed Settings")]
        [Range(1, 300)][SerializeField] private float m_totalPuzzleIntTime = 120.0f;
        [Range(1, 300)][SerializeField] private float m_totalNormalIntTime =  30.0f;

        [Space()]

        [Header("Puzzle Interaction Events")]
        [SerializeField] private UnityEvent m_OnNoPuzzleInteraction;
        [SerializeField] private UnityEvent m_OnNoNormalInteraction;

        private float m_lastPuzzleInteraction = 0.0f;
        private float m_lastNormalInteraction = 0.0f;

        private Puzzle m_curPuzzle = null;

        public Puzzle CurrentPuzzle { 
            private get { return m_curPuzzle; }
            set { m_curPuzzle = value; }
        }

        void Update() {
            m_lastPuzzleInteraction += Time.deltaTime;
            m_lastNormalInteraction += Time.deltaTime;

            if(m_lastNormalInteraction >= m_totalNormalIntTime) {
                m_OnNoNormalInteraction.Invoke();
            }

            if(m_lastPuzzleInteraction >= m_totalPuzzleIntTime) {
                m_OnNoPuzzleInteraction.Invoke();
            }
        }

        /// <summary>
        /// Resets the timer for puzzle interaction
        /// </summary>
        public void LogPuzzleInteraction(Puzzle a_puzzleInteractedWith) {
            if (!a_puzzleInteractedWith.m_completed) {
                m_lastPuzzleInteraction = 0.0f;
            }
        }

        /// <summary>
        /// Resets the timer for normal interaction
        /// </summary>
        public void LogNormalInteraction() {
            m_lastNormalInteraction = 0.0f;
        }
    }
}
