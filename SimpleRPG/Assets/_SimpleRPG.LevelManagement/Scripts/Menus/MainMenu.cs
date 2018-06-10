using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {

        [SerializeField] private float playDelay = 0.25f;

        [SerializeField] private TransitionFader startTransitionFaderPrefab;

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionFaderPrefab);

            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(playDelay);

            GameMenu.Open();
        }

        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }

    }
}