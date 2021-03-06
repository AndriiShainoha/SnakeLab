﻿using Newtonsoft.Json;
using SnakeLab.Entities;
using SnakeLab.Entities.Food;
using SnakeLab.Entities.Observer;
using SnakeLab.Entities.SnakeModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeLab
{
    class GameWorld
    {
        private MainWindow mainWindow;
        public int ElementSize { get; private set; }
        public int ColumnCount { get; private set; }
        public int RowCount { get; private set; }
        public double GameAreaWidth { get; private set; }
        public double GameAreaHeight { get; private set; }
        Random _randoTron;
        private Apple Apple { get; set; }
        public SimpleSnake SimpleSnake { get; set; }

        public List<IObserver> observers;

        DispatcherTimer _gameLoopTimer;
        public bool IsRunning { get; set; }
        public IGameMode gameMode { get; set; }

        public GameWorld(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            _randoTron = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);
            observers = new List<IObserver>();
        }

        public void SetGameMode(IGameMode gameMode)
        {
            this.gameMode = gameMode;
        }

        public void InitializeGame(int elementSize)
        {
            ElementSize = elementSize;
            GameAreaWidth = mainWindow.GameWorld.ActualWidth;
            GameAreaHeight = mainWindow.GameWorld.ActualHeight;
            ColumnCount = (int)GameAreaWidth / ElementSize;
            RowCount = (int)GameAreaHeight / ElementSize;

            DrawGameWorld();
            InitializeSnake();
            InitializeTimer();
            IsRunning = true;
        }

        private void InitializeTimer()
        {
            int difficulty = gameMode.GetModeForGame();
            var interval = TimeSpan.FromSeconds(0.1 + .9 / difficulty).Ticks;
            _gameLoopTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromTicks(interval)
            };
            _gameLoopTimer.Tick += MainGameLoop;
            _gameLoopTimer.Start();
        }

        private void InitializeSnake()
        {
            SnakeCreator snakeCreator;
            if(mainWindow.BlueColor.IsChecked == true)
            {
                snakeCreator = new BlueSkinSnakeCreator();
                SimpleSnake = snakeCreator.Create(ElementSize);
                SimpleSnake.SetState(new HungrySimpleSnakeState(mainWindow));
                SimpleSnake.GetInfo();
            }

            if (mainWindow.GreenColor.IsChecked == true)
            {
                snakeCreator = new GreenSkinSnakeCreator();
                SimpleSnake = snakeCreator.Create(ElementSize);
                SimpleSnake.SetState(new HungrySimpleSnakeState(mainWindow));
                SimpleSnake.GetInfo();
            }

            if (mainWindow.YellowColor.IsChecked == true)
            {
                snakeCreator = new YellowSkinSnakeCreator();
                SimpleSnake = snakeCreator.Create(ElementSize);
                SimpleSnake.SetState(new HungrySimpleSnakeState(mainWindow));
                SimpleSnake.GetInfo();

            }
            SerializeInJson(SimpleSnake);
            SimpleSnake.PositionFirstElement(ColumnCount, RowCount, MovementDirection.Right);
        }

        public void SerializeInJson(SimpleSnake simpleSnake)
        {
            string path = @"D:\SnakeLab3\SnakeLab\serializer.json";
        }

        private void MainGameLoop(object sender, EventArgs e)
        {
            SimpleSnake.MoveSnake();
            CheckCollision();
            CreateApple();
            Draw();
        }

        private void MainGameOnlyLoop(object sender, EventArgs e)
        {
            SimpleSnake.MoveSnake();
            CheckCollision();
            CreateOnlyApple();
            Draw();
        }

        private void Draw()
        {
            DrawSnake();
            if (mainWindow.demoCheckBox.IsChecked == true)
            {
                DrawOnlyApple();
            }
            else
            {
                DrawApple();
            }
        }

        private void DrawGameWorld()
        {
            int i = 0;
            for (; i < RowCount; i++)
                mainWindow.GameWorld.Children.Add(GenerateHorizontalWorldLine(i));
            int j = 0;
            for (; j < ColumnCount; j++)
                mainWindow.GameWorld.Children.Add(GenerateVerticalWorldLine(j));
            mainWindow.GameWorld.Children.Add(GenerateVerticalWorldLine(j));
            mainWindow.GameWorld.Children.Add(GenerateHorizontalWorldLine(i));
        }

        private void DrawSnake()
        {
            foreach (var snakeElement in SimpleSnake.Elements)
            {
                if (!mainWindow.GameWorld.Children.Contains(snakeElement.UIElement))
                    mainWindow.GameWorld.Children.Add(snakeElement.UIElement);
                Canvas.SetLeft(snakeElement.UIElement, snakeElement.X + 2);
                Canvas.SetTop(snakeElement.UIElement, snakeElement.Y + 2);
            }
        }

        private void DrawApple()
        {
            if (!mainWindow.GameWorld.Children.Contains(Apple.UIElement))
                mainWindow.GameWorld.Children.Add(Apple.UIElement);
            Canvas.SetLeft(Apple.UIElement, Apple.X + 2);
            Canvas.SetTop(Apple.UIElement, Apple.Y + 2);
        }

        private void DrawOnlyApple()
        {
            if (!mainWindow.GameWorld.Children.Contains(DemoApple.getOnlyAppleInstance(ElementSize).UIElement))
                mainWindow.GameWorld.Children.Add(DemoApple.getOnlyAppleInstance(ElementSize).UIElement);
            Canvas.SetLeft(Apple.UIElement, Apple.X + 2);
            Canvas.SetTop(Apple.UIElement, Apple.Y + 2);
        }

        private Line GenerateVerticalWorldLine(int j)
        {
            return new Line
            {
                Stroke = Brushes.Black,
                X1 = j * ElementSize,
                Y1 = 0,
                X2 = j * ElementSize,
                Y2 = ElementSize * RowCount
            };
        }

        private Line GenerateHorizontalWorldLine(int i)
        {
            return new Line
            {
                Stroke = Brushes.Black,
                X1 = 0,
                Y1 = i * ElementSize,
                X2 = ElementSize * ColumnCount,
                Y2 = i * ElementSize
            };
        }

        private void CheckCollision()
        {
            if (CollisionWithApple())
                ProcessCollisionWithApple();
            if (SimpleSnake.CollisionWithSelf() || CollisionWithWorldBounds())
            {
                mainWindow.GameOver();
                StopGame();
            }
        }

        private bool CollisionWithApple()
        {
            if (Apple == null || SimpleSnake == null || SimpleSnake.Head == null)
                return false;
            SnakeElement head = SimpleSnake.Head;
            return (head.X == Apple.X && head.Y == Apple.Y);
        }

        private void ProcessCollisionWithApple()
        {
            mainWindow.IncrementScore();
            mainWindow.GameWorld.Children.Remove(Apple.UIElement);
            Apple = null;
            SimpleSnake.Grow();
            IncreaseGameSpeed();
        }

        private void CreateApple()   
        {
            SimpleSnake.Eat();
            if (Apple != null)
            {
                return;
            }
            Apple = new ClassicApple(ElementSize)
            {
                X = _randoTron.Next(0, ColumnCount) * ElementSize,
                Y = _randoTron.Next(0, RowCount) * ElementSize
            };
        }

        private void CreateOnlyApple()
        {
            if (Apple != null)
                return;
            DemoApple onlyApple = DemoApple.getOnlyAppleInstance(ElementSize);
        }

        private bool CollisionWithWorldBounds()
        {
            if (SimpleSnake == null || SimpleSnake.Head == null)
                return false;
            var snakeHead = SimpleSnake.Head;
            return (snakeHead.X > GameAreaWidth - ElementSize ||
                snakeHead.Y > GameAreaHeight - ElementSize ||
                snakeHead.X < 0 || snakeHead.Y < 0);
        }

        public void StopGame()
        {
            _gameLoopTimer.Stop();
            _gameLoopTimer.Tick -= MainGameLoop;
            IsRunning = false;
        }

        private void IncreaseGameSpeed()
        {
            var part = _gameLoopTimer.Interval.Ticks / 10;
            _gameLoopTimer.Interval = TimeSpan.FromTicks(_gameLoopTimer.Interval.Ticks - part);
        }

        public void PauseGame()
        {
            _gameLoopTimer.Stop();
            IsRunning = false;
        }
        public void ContinueGame()
        {
            _gameLoopTimer.Start();
            IsRunning = true;
        }

        internal void UpdateMovementDirection(MovementDirection movementDirection)
        {
            if (SimpleSnake != null)
                SimpleSnake.UpdateMovementDirection(movementDirection);
        }
    }
}
