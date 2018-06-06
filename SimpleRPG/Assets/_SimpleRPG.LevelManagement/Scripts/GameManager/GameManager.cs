using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {

        // reference to goal effect
        private GoalEffect _goalEffect;

        // reference to player
        private Objective _objective;

        private bool _isGameOver;
        public bool IsGameOver { get { return _isGameOver; } }

        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        // initialize references
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            _objective = Object.FindObjectOfType<Objective>();
            _goalEffect = Object.FindObjectOfType<GoalEffect>();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        // end the level
        public void EndLevel()
        {

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect != null && !_isGameOver)
            {
                _isGameOver = true;
                _goalEffect.PlayEffect();
                WinScreen.Open();
            }
        }


        // check for the end game condition on each frame
        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }
    }
}