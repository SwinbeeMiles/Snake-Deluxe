using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TanTestScript
    {
		//***************************************************************************************************************************************************
		//Game.cs
        [Test]
		public void GameLevelTest()
        {
			//To test if the level is initialised correctly.
            GameObject gameObj = new GameObject();
            Game game = gameObj.AddComponent<Game>();

			int expectedLevel = 1;

			Assert.AreEqual(expectedLevel, game.Level,"The game initial level should be 1.");
        }

        [Test]
        public void GameScoreTest()
        {
			//To test if the score is initialised correctly.
            GameObject gameObj = new GameObject();
            Game game = gameObj.AddComponent<Game>();

			int expectedScore = 0;

            Assert.AreEqual(expectedScore, game.Score,"The initial game score should be 0.");
        }

        [Test]
        public void GameDeadTest()
        {
			//To test if the condition of the snake is initialised correctly.
            GameObject gameObj = new GameObject();
            Game game = gameObj.AddComponent<Game>();

			bool expectedSnakeCondition = false;

            Assert.AreEqual(expectedSnakeCondition, game.dead,"The initial condition of the snake should not be dead(false).");
        }

        [Test]
        public void GamePausedTest()
        {
			//To test if the paused is initialised correctly.
            GameObject gameObj = new GameObject();
            Game game = gameObj.AddComponent<Game>();

			bool expectedPauseState = false;

            Assert.AreEqual(expectedPauseState, game.Paused,"The initial pause state should be false.");
        }

		[Test]
        public void GameTempScoreTest()
        {
			//To test if the tempScore is initialised correctly.
            GameObject gameObj = new GameObject();
            Game game = gameObj.AddComponent<Game>();

			int expectedTempScore = 0;

            Assert.AreEqual(expectedTempScore, game.tempScore,"The initial temporary score variable should be 0.");
        }
		//***************************************************************************************************************************************************
		//GameOverPanel.cs
		[Test]
        public void GameOverScoreTest()
        {
			//To test if the paused is initialised correctly.
            GameObject gameObj = new GameObject();
            GameOverPanel gameOver = gameObj.AddComponent<GameOverPanel>();

			int expectedScore = 0;

            Assert.AreEqual(expectedScore, gameOver.Score,"The initial game over score should be 0 because they user haven't started the game or did not score any.");
        }

		//***************************************************************************************************************************************************
		//GamePanel.cs
		[Test]
        public void GamePanelScoreTest()
        {
			//To test if the paused is initialised correctly in GameOverPanel.cs.
            GameObject gameObj = new GameObject();
            GamePanel gamePanel = gameObj.AddComponent<GamePanel>();

			int expectedScore = 0;

            Assert.AreEqual(expectedScore, gamePanel.Score,"The initial GamePanel score should be 0 until the user eat some food on the board.");
        }

		[Test]
        public void GamePanelLevelTest()
        {
			//To test if the paused is initialised correctly in GameOverPanel.cs.
            GameObject gameObj = new GameObject();
            GamePanel gamePanel = gameObj.AddComponent<GamePanel>();

			int expectedLevel = 0;

            Assert.AreEqual(expectedLevel, gamePanel.Level,"The initial GamePanel Level indicated on the top right corner of the game should be 0 until user start the game.");
        }

		//***************************************************************************************************************************************************
		//NextLevelMenu.cs
		public void NextLevelMenuLevelTest()
        {
			//To test if the paused is initialised correctly in GameOverPanel.cs.
            GameObject gameObj = new GameObject();
            NextLevelMenu nextLevel = gameObj.AddComponent<NextLevelMenu>();

			int expectedLevel = 0;

            Assert.AreEqual(expectedLevel, nextLevel.Level,"The initial Next Level indicated in the NextLeveMenu scene should be 0 at start until user start the game.");
        }
	}
}
