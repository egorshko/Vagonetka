﻿using UnityEngine;


namespace Vagonetka
{
    public class UIController : MonoBehaviour
    {
        private MainMenu _mainMenu;
        private InGameUI _inGameUI;
        private PauseMenu _pauseMenu;
        private EndGameMenu _endGameMenu;

        private MainGameController _mainGameController;


        private void Awake()
        {
            _mainMenu = GetComponentInChildren<MainMenu>();
            _inGameUI = GetComponentInChildren<InGameUI>();
            _pauseMenu = GetComponentInChildren<PauseMenu>();
            _endGameMenu = GetComponentInChildren<EndGameMenu>();

            _mainGameController = FindObjectOfType<MainGameController>();
            
            SwitchUI(UIState.MainMenu);
            
            Time.timeScale = 0;
        }

        public void SwitchUI(UIState state)
        {
            switch(state)
            {
                case UIState.MainMenu:
                    _mainMenu.Show();
                    _inGameUI.Hide();
                    _pauseMenu.Hide();
                    _endGameMenu.Hide();
                    break;
                case UIState.InGame:
                    _mainMenu.Hide();
                    _inGameUI.Show();
                    _pauseMenu.Hide();
                    _endGameMenu.Hide();
                    break;
                case UIState.Pause:
                    _mainMenu.Hide();
                    _inGameUI.Hide();
                    _pauseMenu.Show();
                    _endGameMenu.Hide();
                    break;
                case UIState.EndGame:
                    _mainMenu.Hide();
                    _inGameUI.Hide();
                    _pauseMenu.Hide();
                    _endGameMenu.Show();
                    break;
            }
        }

        public void StartGame()
        {
            Debug.Log("StartGame");
            Time.timeScale = 1;
            SwitchUI(UIState.InGame);
            _mainGameController.StartGame();
        }
        public void NextLevel()
        {
            SwitchUI(UIState.InGame);
            _mainGameController.NextLevel();
        }
        public void PauseGame()
        {
            Time.timeScale = 0;
            SwitchUI(UIState.Pause);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            SwitchUI(UIState.InGame);
        }
        public void EndGame()
        {
            SwitchUI(UIState.EndGame);
        }
    }
}
