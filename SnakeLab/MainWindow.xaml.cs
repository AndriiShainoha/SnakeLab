﻿using SnakeLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private GameWorld _gameWorld;
        int apples, score, level;

        protected override void OnContentRendered(EventArgs e)
        {
            _gameWorld = new GameWorld(this);
            InitializeScore();
            base.OnContentRendered(e);
        }

        private void InitializeScore()
        {
            apples = 0;
            score = level = 1;
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_gameWorld != null)
                switch (e.Key)
                {
                    case Key.W:
                        _gameWorld.UpdateMovementDirection(MovementDirection.Up);
                        break;
                    case Key.A:
                        _gameWorld.UpdateMovementDirection(MovementDirection.Left);
                        break;
                    case Key.S:
                        _gameWorld.UpdateMovementDirection(MovementDirection.Down);
                        break;
                    case Key.D:
                        _gameWorld.UpdateMovementDirection(MovementDirection.Right);
                        break;
                    case Key.Escape:
                        PauseGame();
                        break;
                }
        }

        internal void GameOver()
        {
            _gameWorld.StopGame();
            MessageBox.Show($"You have reached level {level}. Your score is {score}. You ate {apples} apples! ", " Game Over!");
        }

        private void RestartClick(object sender, RoutedEventArgs e)
        {
            _gameWorld.StopGame();
            _gameWorld = new GameWorld(this);
            GameWorld.Children.Clear();
            if (!_gameWorld.IsRunning)
            {
                _gameWorld.InitializeGame((int)DifficultySlider.Value, (int)ElementSizeSlider.Value);
                StartBtn.IsEnabled = false;
            }
        }

        private void PauseGame()
        {
            _gameWorld.PauseGame();
            MessageBox.Show("Fortfahren?", "Spiel pausiert");
            _gameWorld.ContinueGame();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            if (!_gameWorld.IsRunning)
            {
                _gameWorld.InitializeGame((int)DifficultySlider.Value, (int)ElementSizeSlider.Value);
                StartBtn.IsEnabled = false;
            }
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            StartBtn.IsEnabled = !StartBtn.IsEnabled;
            RestartBtn.IsEnabled = !RestartBtn.IsEnabled;
            this.DialogHost.IsOpen = !this.DialogHost.IsOpen;
        }
        internal void IncrementScore()
        {
            apples += 1;
            if (apples % 3 == 0)
                level += 1;
            score += (int)DifficultySlider.Value * level;
            UpdateScore();
        }

        internal void UpdateScore()
        {
            ApplesLbl.Content = $"Apples: {apples}";
            ScoreLbl.Content = $"Score: {score}";
            LevelLbl.Content = $"Level: {level }";
        }
    }
}
