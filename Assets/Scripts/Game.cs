using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class Game : MonoBehaviour
{
	private bool accessFlag = false;

	public bool getAccessFlag
	{
		get
		{
			return accessFlag;
		}
	}

	private int counter = 0;
    /// <summary>
    /// Variable used for game update delay calcuations.
    /// </summary>
    private float time;

    /// <summary>
    /// Holds last started bonus placing coroutine.
    /// </summary>
    private IEnumerator bonusCoroutine;

    /// <summary>
    /// Object responisble for managing sound effects.
    /// </summary>
    private SoundManager soundManager;

    private Snake snake;

    /// <summary>
    /// Position of an apple (1 point fruit).
    /// </summary>
    private IntVector2 applePosition;

    /// <summary>
    /// Position of 10 point (bonus) fruit.
    /// </summary>
    private IntVector2 bonusPosition;

    /// <summary>
    /// Position of a wall.
    /// </summary>
    private IntVector2 wallPosition;

    /// <summary>
    /// Position of a poison.
    /// </summary>
    private IntVector2 poisonPosition;

    /// <summary>
    /// Specifies if bonus is visible and active.
    /// </summary>
    private bool bonusActive;

    /// <summary>
    /// Game controller.
    /// </summary>
    private Controller controller;

    /// <summary>
    /// Menu panel.
    /// </summary>
    public MenuPanel Menu;
    /// <summary>
    /// Game over panel.
    /// </summary>
    public GameOverPanel GameOver;
    /// <summary>
    /// Main game panel (with board).
    /// </summary>
    public GamePanel GamePanel;

    public NextLevelMenu NextLevelMenu;

    public EndGameMenu EndGameMenu;
    public PauseMenu PauseMenu;
    /// <summary>
    /// Parameter specyfying delay between snake movements (in seconds).
    /// </summary>
    [Range(0f, 3f)]
    public float GameSpeed;

    /// <summary>
    /// Has to be set to game's board object.
    /// </summary>
    public Board Board;

    private int _score;
    private int _highScore;
    private int tempScore = 0;
    public int _level = 0;
    public bool dead = false;

    /// <summary>
    /// Current score.
    /// </summary>
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            GamePanel.Score = value;
            GameOver.Score = value;

            if (value > HighScore)
            {
                HighScore = value;
            }
        }
    }

    /// <summary>
    /// Current level.
    /// </summary>
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            GamePanel.Level = value;
            NextLevelMenu.Level = value;
        }
    }

    /// <summary>
    /// Current high score.
    /// </summary>
    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            PlayerPrefs.SetInt("High Score", value);
            //GamePanel.HighScore = value;
        }
    }

    /// <summary>
    /// Determines if games is paused (when true) or running (when false).
    /// </summary>
    public bool Paused { get; private set; }

	public void InterruptGame()
	{
		StopCoroutine(bonusCoroutine);
		Paused = true;
	}

    // Use this for initialization
    void Start()
    {
        // Display current high score.
        HighScore = PlayerPrefs.GetInt("High Score", 0);

		// Find sound manager
        soundManager = GetComponent<SoundManager>();

        // Show main menu
        ShowMenu();

        // Set controller
        controller = GetComponent<Controller>();

        // Creates snake
        snake = new Snake(Board);

        // Pause the game
		Paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        while (time > GameSpeed)
        {
            time -= GameSpeed;
            UpdateGameState();
			Time.timeScale = 0.20f; //0.25f
			if (accessFlag == true)
			{
				Time.timeScale = 1;
				if (Score >= 1 && Level == 0 && dead == false)
				{
                    Level = 0;
					tempScore = Score;
					Time.timeScale = 0;
					StopCoroutine(bonusCoroutine);
					NextLevelMenu.gameObject.SetActive(true);
				}

				else if (Score >= 1 && Level == 1 && dead == false)
				{
					tempScore = Score;
					Time.timeScale = 0;
					StopCoroutine(bonusCoroutine);
					NextLevelMenu.gameObject.SetActive(true);
				}

				else if (Score >= 1 && Level == 2 && dead == false)
				{
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 3 && dead == false)
                {
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 4 && dead == false)
                {
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 5 && dead == false)
                {
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 6 && dead == false)
                {
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 7 && dead == false)
                {
                    tempScore = Score;
                    Time.timeScale = 0;
                    StopCoroutine(bonusCoroutine);
                    NextLevelMenu.gameObject.SetActive(true);
                }
                else if (Score >= 1 && Level == 8 && dead == false)
                {
                    StopCoroutine(bonusCoroutine);
                    tempScore = 0;
                    Level = 0;
                    NextLevelMenu.gameObject.SetActive(false);
                    EndGameMenu.gameObject.SetActive(true);
                }
            }
        }
    }

    public void Pause()
	{
		Paused = true;
		PauseMenu.gameObject.SetActive(true);
		Time.timeScale = 0;
		if (accessFlag == false)
		{
			soundManager.PlayPause();
		}
	}

	public void Unpause()
	{
		if (accessFlag == false)
		{
			soundManager.StopPause();
		}
		Paused = false;
		PauseMenu.gameObject.SetActive(false);
		controller.Resume();
		Time.timeScale = 1;
	}

	public void Instruction()
	{
		if (accessFlag == false)
		{
			soundManager.PlayInstruction();
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}

    /// <summary>
    /// Updates game state.
    /// </summary>
    private void UpdateGameState()
    {
		if (!Paused && snake != null)
        {
            var dir = controller.NextDirection();
			var lastdir = controller.PreviousDirection();

			// New head position
			var head = snake.NextHeadPosition(dir);

            var x = head.x;
            var y = head.y;

            if (snake.WithoutTail.Contains(head))
            {
				if (accessFlag == true)
				{
					// Snake has bitten its tail - game over
					dead = true;
					StartCoroutine(GameOverCoroutine());
					return;
				}
                
            }

            if (x >= 0 && x < Board.Columns && y >= 0 && y < Board.Rows)
            {
				if (head == applePosition)
				{
					soundManager.PlayAppleSoundEffect();
					snake.Move(dir, true);
					Score += 1;
					PlantAnApple();
				}

                else if (Board[head].Content == TileContent.Poison)
                {
                    snake.Remove(dir, true);
                    Score -= 1;
                    PlantAPoison();
                    if (snake.isSmallestSize)
                    {
                        StartCoroutine(GameOverCoroutine());
                    }
                }
                else if (Board[head].Content == TileContent.Poison)
                {
                    snake.Remove(dir, true);
                    Score -= 1;
                    PlantAPoison();
                    if (snake.isSmallestSize)
                    {
                        StartCoroutine(GameOverCoroutine());
                    }
                }

                else if (head == bonusPosition && bonusActive)
				{
					soundManager.PlayBonusSoundEffect();
					snake.Move(dir, true);
					Score += 2;
					StopCoroutine(bonusCoroutine);
					PlantABonus();
				}

				else if (Board[head].Content == TileContent.Wall || Board[head].Content == TileContent.Wall1 || Board[head].Content == TileContent.Wall2 || Board[head].Content == TileContent.Wall3)
				{
					StartCoroutine(GameOverCoroutine());
				}

				else
				{
					snake.Move(dir, false);
					print("appleY" + applePosition.y);
					print("appleX" + applePosition.x);
					print("snakeY" + snake.Head.y);
					print("snakeX" + snake.Head.x);
					if (accessFlag == false)
					{
						counter++;
						if (counter == 1) //Frequency of beeps
						{
							if (((applePosition.y < snake.Head.y && applePosition.x > snake.Head.x) || (applePosition.y > snake.Head.y && applePosition.x > snake.Head.x)) && (lastdir == Vector2.up))
							{
								soundManager.PlayRightBeepSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x > snake.Head.x) && (lastdir == Vector2.up))
							{
								soundManager.PlayRightTickSoundEffect();
							}
							else if (((applePosition.y < snake.Head.y && applePosition.x < snake.Head.x) || (applePosition.y > snake.Head.y && applePosition.x < snake.Head.x)) && (lastdir == Vector2.up))
							{
								soundManager.PlayLeftBeepSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x < snake.Head.x) && (lastdir == Vector2.up))
							{
								soundManager.PlayLeftTickSoundEffect();
							}
							else if ((applePosition.y <= snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.up))
							{
								soundManager.PlayCenterBeepSoundEffect();
							}

							else if (((applePosition.y > snake.Head.y && applePosition.x < snake.Head.x) || (applePosition.y > snake.Head.y && applePosition.x > snake.Head.x)) && (lastdir == Vector2.right))
							{
								soundManager.PlayRightBeepSoundEffect();
							}
							else if ((applePosition.y > snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.right))
							{
								soundManager.PlayRightTickSoundEffect();
							}
							else if (((applePosition.y < snake.Head.y && applePosition.x < snake.Head.x) || (applePosition.y < snake.Head.y && applePosition.x > snake.Head.x)) && (lastdir == Vector2.right))
							{
								soundManager.PlayLeftBeepSoundEffect();
							}
							else if ((applePosition.y < snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.right))
							{
								soundManager.PlayLeftTickSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x >= snake.Head.x) && (lastdir == Vector2.right))
							{
								soundManager.PlayCenterBeepSoundEffect();
							}

							else if (((applePosition.y < snake.Head.y && applePosition.x > snake.Head.x) || (applePosition.y < snake.Head.y && applePosition.x < snake.Head.x)) && (lastdir == Vector2.left))
							{
								soundManager.PlayRightBeepSoundEffect();
							}
							else if ((applePosition.y < snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.left))
							{
								soundManager.PlayRightTickSoundEffect();
							}
							else if (((applePosition.y > snake.Head.y && applePosition.x > snake.Head.x) || (applePosition.y > snake.Head.y && applePosition.x < snake.Head.x)) && (lastdir == Vector2.left))
							{
								soundManager.PlayLeftBeepSoundEffect();
							}
							else if ((applePosition.y > snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.left))
							{
								soundManager.PlayLeftTickSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x <= snake.Head.x) && (lastdir == Vector2.left))
							{
								soundManager.PlayCenterBeepSoundEffect();
							}

							else if (((applePosition.y > snake.Head.y && applePosition.x > snake.Head.x) || (applePosition.y < snake.Head.y && applePosition.x > snake.Head.x)) && (lastdir == Vector2.down))
							{
								soundManager.PlayRightBeepSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x > snake.Head.x) && (lastdir == Vector2.down))
							{
								soundManager.PlayRightTickSoundEffect();
							}
							else if (((applePosition.y > snake.Head.y && applePosition.x < snake.Head.x) || (applePosition.y < snake.Head.y && applePosition.x < snake.Head.x)) && (lastdir == Vector2.down))
							{
								soundManager.PlayLeftBeepSoundEffect();
							}
							else if ((applePosition.y == snake.Head.y && applePosition.x < snake.Head.x) && (lastdir == Vector2.down))
							{
								soundManager.PlayLeftTickSoundEffect();
							}
							else if ((applePosition.y >= snake.Head.y && applePosition.x == snake.Head.x) && (lastdir == Vector2.down))
							{
								soundManager.PlayCenterBeepSoundEffect();
							}

							if ((snake.Head.x >= 0 && snake.Head.x < 3) || (snake.Head.x > 26 && snake.Head.x < 30) || (snake.Head.y >= 0 && snake.Head.y < 3) || (snake.Head.y >= 17 && snake.Head.y < 20))
							{
								soundManager.PlayAlert();
							}
							counter = 0;
						}
					}
                }
            }

            else
            {
                // Head is outside board's bounds - game over.
                dead = true;
                StartCoroutine(GameOverCoroutine());
            }
        }
    }

    /// <summary>
    /// Shows main menu.
    /// </summary>
    public void ShowMenu()
    {
		if (accessFlag == false)
		{
			soundManager.StopGameOver();
			soundManager.StopPause();
		}
        HideAllPanels();
        Menu.gameObject.SetActive(true);
		if (accessFlag == false)
		{
			soundManager.PlayMainMenu();
		}
    }

    /// <summary>
    /// Shows game over panel.
    /// </summary>
    public void ShowGameOver()
    {
		if (accessFlag == false)
		{
			soundManager.StopMainMenu();
			soundManager.StopPause();
		}
        HideAllPanels();
        GameOver.gameObject.SetActive(true);
		if (accessFlag == false)
		{
			soundManager.PlayGameOver();
		}
    }

    /// <summary>
    /// Shows the board and starts the game.
    /// </summary>
    public void StartGame()
    {
        HideAllPanels();
        Restart();
        dead = false;
        GamePanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides all panels.
    /// </summary>
    private void HideAllPanels()
    {
		if (accessFlag == false)
		{
			soundManager.StopGameOver();
			soundManager.StopPause();
			soundManager.StopMainMenu();
			soundManager.StopInstruction();
		}
        Menu.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
		PauseMenu.gameObject.SetActive(false);
        NextLevelMenu.gameObject.SetActive(false);
        EndGameMenu.gameObject.SetActive(false);
    }

    /// <summary>
    /// Returns game to initial conditions.
    /// </summary>
    private void Restart()
    {
		counter = 0;
        // Resets the controller.
        controller.Reset();

        // Set score
        Score = 0;

        // Disable bonus
        bonusActive = false;

        // Clear board
        Board.Reset();

        // Resets snake
        snake.Reset();
        // Start bonus coroutine
        if (accessFlag == true)
        {
            BuildMultipleWallOne(TileContent.Wall);
            PlantABonus();
            for (int x = 0; x < 10; x++)
            {      
                PlantAPoison();
            }
        }

        // Plant an apple
        PlantAnApple();

        Time.timeScale = 1;

        // Start the game
        Paused = false;
        time = 0;
    }

    /// <summary>
    /// Starts bonus placing coroutine
    /// </summary>
    private void PlantABonus()
    {
        bonusActive = false;
        bonusCoroutine = BonusCoroutine();
        StartCoroutine(bonusCoroutine);
    }

    /// <summary>
    /// Puts an apple in new position.
    /// </summary>
    private void PlantAnApple()
    {
        if (Board[applePosition].Content == TileContent.Apple)
        {
            Board[applePosition].Content = TileContent.Empty;
        }

        var emptyPositions = Board.EmptyPositions.ToList();
        if (emptyPositions.Count == 0)
        {
            return;
        }
        applePosition = emptyPositions.RandomElement();
        while(Board[applePosition].Content != TileContent.Apple)
        {
            if((Board[applePosition].Content == TileContent.Wall) || (Board[applePosition].Content == TileContent.Wall1) || (Board[applePosition].Content == TileContent.Wall2) || (Board[applePosition].Content == TileContent.Wall3) || (Board[applePosition].Content == TileContent.Poison))
            {
                applePosition = emptyPositions.RandomElement();
            }
            else
            {
                Board[applePosition].Content = TileContent.Apple;
                break;
            }
        }
        print(applePosition);
    }
    
    /// <summary>
    /// Puts a poison in new position.
    /// </summary>
    private void PlantAPoison()
    {
        var emptyPositions = Board.EmptyPositions.ToList();
        if (emptyPositions.Count == 0)
        {
            return;
        }
        poisonPosition = emptyPositions.RandomElement();
        Board[poisonPosition].Content = TileContent.Poison;
        print(poisonPosition);
    }
    
    /// <summary>
    /// Couroutine responsible for placing and removing bonus from the board.
    /// It waits for a random period of time, puts the bonus on the board, and then removes it after constant delay.
    /// </summary>
    /// <returns></returns>
    private IEnumerator BonusCoroutine()
    {
        // Wait for a random period of time
        yield return new WaitForSeconds(Random.Range(GameSpeed * 20, GameSpeed * 40));

        // Put a bonus on a board at a random place
        var emptyPositions = Board.EmptyPositions.ToList();
        if (emptyPositions.Count == 0)
        {
            yield break;
        }
        bonusPosition = emptyPositions.RandomElement();
        Board[bonusPosition].Content = TileContent.Bonus;
        bonusActive = true;

        // Wait
        yield return new WaitForSeconds(GameSpeed * 16);

        // Start bonus to blink
        for (int i = 0; i < 5; i++)
        {
            Board[bonusPosition].ContentHidden = true;
            yield return new WaitForSeconds(GameSpeed * 1.5f);
            Board[bonusPosition].ContentHidden = false;
            yield return new WaitForSeconds(GameSpeed * 1.5f);
        }

        // Remove a bonus and restart the coroutine
        bonusActive = false;
        Board[bonusPosition].Content = TileContent.Empty;

        bonusCoroutine = BonusCoroutine();
        yield return StartCoroutine(bonusCoroutine);
    }

    /// <summary>
    /// Courotine that is started when game is over. Causes snake to blink and then shows game over panel.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GameOverCoroutine()
    {
        // Play game over sound effect
        soundManager.PlayGameOverSoundEffect();

		// Stop bonus coroutine
		if (accessFlag == true)
		{
			StopCoroutine(bonusCoroutine);
		}

        // Pause the game
        Paused = true;

        // Start snake blinking
        for (int i = 0; i < 3; i++)
        {
            snake.Hide();
            yield return new WaitForSeconds(GameSpeed * 1.5f);
            snake.Show();
            yield return new WaitForSeconds(GameSpeed * 1.5f);
        }

        // Show "game over" panel
        ShowGameOver();
        Level = 0;
        dead = true;
    }

    private void BuildAWall(int x, int y, TileContent wallType)
    {
        wallPosition.x = x;
        wallPosition.y = y;
        Board[wallPosition].Content = wallType;
    }

    //Build multiple wall by calling the BuildAWall function inside this function and pass in x-axis and y-axis value.
    private void BuildMultipleWallOne(TileContent wallTextureType)
    {
        for (int x = 6; x < 11; x++)
        {
            BuildAWall(x, 4, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
        }

        for (int x = 19; x < 24; x++)
        {
            BuildAWall(x, 4, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
        }

        for (int y = 5; y < 9; y++)
        {
            BuildAWall(6, y, wallTextureType);
            BuildAWall(23, y, wallTextureType);
        }

        for (int y = 12; y < 16; y++)
        {
            BuildAWall(6, y, wallTextureType);
            BuildAWall(23, y, wallTextureType);
        }

        for (int y = 7; y < 14; y++)
        {
            BuildAWall(15, y, wallTextureType);
        }

        for (int x = 12; x < 19; x++)
        {
            BuildAWall(x, 10, wallTextureType);
        }
    }

    private void BuildMultipleWallTwo(TileContent wallTextureType)
    {
        for (int y = 4; y < 9; y++)
        {
            BuildAWall(12, y, wallTextureType);
            BuildAWall(18, y, wallTextureType);
        }

        for (int y = 12; y < 17; y++)
        {
            BuildAWall(12, y, wallTextureType);
            BuildAWall(18, y, wallTextureType);
        }

        for (int x = 7; x < 12; x++)
        {
            BuildAWall(x, 8, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int x = 19; x < 24; x++)
        {
            BuildAWall(x, 8, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        BuildAWall(15, 10, wallTextureType);
    }

    private void BuildMultipleWallThree(TileContent wallTextureType)
    {
        for (int y = 0; y < 5; y++)
        {
            BuildAWall(12, y, wallTextureType);
            BuildAWall(18, y, wallTextureType);
        }

        for (int y = 15; y < 20; y++)
        {
            BuildAWall(12, y, wallTextureType);
            BuildAWall(18, y, wallTextureType);
        }

        for (int x = 0; x < 4; x++)
        {
            BuildAWall(x, 5, wallTextureType);
            BuildAWall(x, 15, wallTextureType);
        }

        for (int x = 26; x < 30; x++)
        {
            BuildAWall(x, 5, wallTextureType);
            BuildAWall(x, 15, wallTextureType);
        }

        for (int x = 14; x < 17; x++)
        {
            BuildAWall(x, 8, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int y = 8; y < 13; y++)
        {
            BuildAWall(10, y, wallTextureType);
            BuildAWall(20, y, wallTextureType);
            BuildAWall(2, y, wallTextureType);
            BuildAWall(28, y, wallTextureType);
        }
    }

    private void BuildMultipleWallFour(TileContent wallTextureType)
    {
        //Row1
        for (int x = 10; x < 11; x++)
        {
            BuildAWall(x, 4, wallTextureType);
        }
        for (int x = 9; x < 12; x++)
        {
            BuildAWall(x, 5, wallTextureType);
        }
        for (int x = 8; x < 13; x++)
        {
            BuildAWall(x, 6, wallTextureType);
        }
        for (int x = 9; x < 12; x++)
        {
            BuildAWall(x, 7, wallTextureType);
        }
        for (int x = 10; x < 11; x++)
        {
            BuildAWall(x, 8, wallTextureType);
        }
        for (int x = 17; x < 18; x++)
        {
            BuildAWall(x, 4, wallTextureType);
        }
        for (int x = 16; x < 19; x++)
        {
            BuildAWall(x, 5, wallTextureType);
        }
        for (int x = 15; x < 20; x++)
        {
            BuildAWall(x, 6, wallTextureType);
        }
        for (int x = 16; x < 19; x++)
        {
            BuildAWall(x, 7, wallTextureType);
        }
        for (int x = 17; x < 18; x++)
        {
            BuildAWall(x, 8, wallTextureType);
        }
        for (int x = 24; x < 25; x++)
        {
            BuildAWall(x, 4, wallTextureType);
        }
        for (int x = 23; x < 26; x++)
        {
            BuildAWall(x, 5, wallTextureType);
        }
        for (int x = 22; x < 27; x++)
        {
            BuildAWall(x, 6, wallTextureType);
        }
        for (int x = 23; x < 26; x++)
        {
            BuildAWall(x, 7, wallTextureType);
        }
        for (int x = 24; x < 25; x++)
        {
            BuildAWall(x, 8, wallTextureType);
        }
        //Row 2
        for (int x = 10; x < 11; x++)
        {
            BuildAWall(x, 11, wallTextureType);
        }
        for (int x = 9; x < 12; x++)
        {
            BuildAWall(x, 12, wallTextureType);
        }
        for (int x = 8; x < 13; x++)
        {
            BuildAWall(x, 13, wallTextureType);
        }
        for (int x = 9; x < 12; x++)
        {
            BuildAWall(x, 14, wallTextureType);
        }
        for (int x = 10; x < 11; x++)
        {
            BuildAWall(x, 15, wallTextureType);
        }
        for (int x = 17; x < 18; x++)
        {
            BuildAWall(x, 11, wallTextureType);
        }
        for (int x = 16; x < 19; x++)
        {
            BuildAWall(x, 12, wallTextureType);
        }
        for (int x = 15; x < 20; x++)
        {
            BuildAWall(x, 13, wallTextureType);
        }
        for (int x = 16; x < 19; x++)
        {
            BuildAWall(x, 14, wallTextureType);
        }
        for (int x = 17; x < 18; x++)
        {
            BuildAWall(x, 15, wallTextureType);
        }
        for (int x = 24; x < 25; x++)
        {
            BuildAWall(x, 11, wallTextureType);
        }
        for (int x = 23; x < 26; x++)
        {
            BuildAWall(x, 12, wallTextureType);
        }
        for (int x = 22; x < 27; x++)
        {
            BuildAWall(x, 13, wallTextureType);
        }
        for (int x = 23; x < 26; x++)
        {
            BuildAWall(x, 14, wallTextureType);
        }
        for (int x = 24; x < 25; x++)
        {
            BuildAWall(x, 15, wallTextureType);
        }
    }

    private void BuildMultipleWallFive(TileContent wallTextureType)
    {
        //Row 1
        int posCount = 0;
        for (int x = 1; x < 30; x++)
        {
            if (posCount >= 3)
            {
                posCount++;
                if (posCount == 6)
                {
                    posCount = 0;
                }
                else
                {
                    continue;
                }
            }
            BuildAWall(x, 1, wallTextureType);
            BuildAWall(x, 2, wallTextureType);
            BuildAWall(x, 3, wallTextureType);
            posCount++;
        }

        //Row 2
        posCount = 0;
        for (int x = 1; x < 30; x++)
        {
            if (posCount >= 3)
            {
                posCount++;
                if (posCount == 6)
                {
                    posCount = 0;
                }
                else
                {
                    continue;
                }
            }
            BuildAWall(x, 6, wallTextureType);
            BuildAWall(x, 7, wallTextureType);
            BuildAWall(x, 8, wallTextureType);
            posCount++;
        }

        //Row 3
        posCount = 0;
        for (int x = 1; x < 30; x++)
        {
            if (posCount >= 3)
            {
                posCount++;
                if (posCount == 6)
                {
                    posCount = 0;
                }
                else
                {
                    continue;
                }
            }
            BuildAWall(x, 11, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
            BuildAWall(x, 13, wallTextureType);
            posCount++;
        }

        //Row 4
        posCount = 0;
        for (int x = 1; x < 30; x++)
        {
            if (posCount >= 3)
            {
                posCount++;
                if (posCount == 6)
                {
                    posCount = 0;
                }
                else
                {
                    continue;
                }
            }
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 17, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
            posCount++;
        }
    }
    private void BuildMultipleWallSix(TileContent wallTextureType)
    {
        for (int y = 3; y < 16; y++)
        {
            if (y == 4)
            {
                continue;
            }
            else
            {
                BuildAWall(4, y, wallTextureType);
            }
        }
        for (int x = 5; x < 26; x++)
        {
            if (x == 25)
            {
                continue;
            }
            else
            {
                BuildAWall(x, 3, wallTextureType);
            }
        }
        for (int y = 3; y < 15; y++)
        {
            if (y == 14)
            {
                continue;
            }
            else
            {
                BuildAWall(26, y, wallTextureType);
            }
        }
        for (int x = 8; x < 27; x++)
        {
            if (x == 9)
            {
                continue;
            }
            else
            {
                BuildAWall(x, 15, wallTextureType);
            }
        }
        for (int y = 7; y < 15; y++)
        {
            if (y == 8)
            {
                continue;
            }
            else
            {
                BuildAWall(8, y, wallTextureType);
            }
        }
        for (int x = 8; x < 22; x++)
        {
            if (x == 21)
            {
                continue;
            }
            else
            {
                BuildAWall(x, 7, wallTextureType);
            }
        }
        for (int y = 7; y < 11; y++)
        {
            if (y == 10)
            {
                continue;
            }
            else
            {
                BuildAWall(22, y, wallTextureType);
            }
        }
        for (int x = 12; x < 23; x++)
        {
            BuildAWall(x, 11, wallTextureType);
        }
    }

    private void BuildMultipleWallSeven(TileContent wallTextureType)
    {
        for (int x=0; x<5; x++)
        {
            BuildAWall(x, 3, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int x=25; x<30; x++)
        {
            BuildAWall(x, 3, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int y=6; y<11; y++)
        {
            BuildAWall(2, y, wallTextureType);
            BuildAWall(28, y, wallTextureType);
            BuildAWall(12, y, wallTextureType);
            BuildAWall(17, y, wallTextureType);
        }

        for (int x=10; x<14; x++)
        {
            BuildAWall(x, 3, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int x=16; x<20; x++)
        {
            BuildAWall(x, 3, wallTextureType);
            BuildAWall(x, 12, wallTextureType);
        }

        for (int x=3; x<7; x++)
        {
            BuildAWall(x, 14, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
        }

        for (int x = 23; x<27; x++)
        {
            BuildAWall(x, 14, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
        }

        for (int x = 10; x<14; x++)
        {
            BuildAWall(x, 14, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
        }

        for (int x = 16; x<20; x++)
        {
            BuildAWall(x, 14, wallTextureType);
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
        }
    }

    private void BuildMultipleWallEight(TileContent wallTextureType)
    {
        BuildAWall(0, 0, wallTextureType);
        BuildAWall(1, 1, wallTextureType);
        BuildAWall(2, 2, wallTextureType);
        BuildAWall(8, 8, wallTextureType);
        BuildAWall(9, 9, wallTextureType);
        BuildAWall(10, 10, wallTextureType);
        BuildAWall(11, 11, wallTextureType);
        BuildAWall(12, 12, wallTextureType);
        BuildAWall(18, 18, wallTextureType);
        BuildAWall(19, 19, wallTextureType);

        BuildAWall(29, 0, wallTextureType);
        BuildAWall(28, 1, wallTextureType);
        BuildAWall(27, 2, wallTextureType);
        BuildAWall(22, 8, wallTextureType);
        BuildAWall(21, 9, wallTextureType);
        BuildAWall(20, 10, wallTextureType);
        BuildAWall(19, 11, wallTextureType);
        BuildAWall(18, 12, wallTextureType);
        BuildAWall(12, 18, wallTextureType);
        BuildAWall(11, 19, wallTextureType);

        for (int y = 0; y<7; y++)
        {
            BuildAWall(15, y, wallTextureType);
        }

        for (int y = 13; y < 20; y++)
        {
            BuildAWall(15, y, wallTextureType);
        }

        BuildAWall(0, 16, wallTextureType);
        BuildAWall(2, 16, wallTextureType);
        BuildAWall(4, 16, wallTextureType);
        BuildAWall(6, 16, wallTextureType);

        BuildAWall(28, 16, wallTextureType);
        BuildAWall(26, 16, wallTextureType);
        BuildAWall(24, 16, wallTextureType);
        BuildAWall(22, 16, wallTextureType);

        for (int y=0; y<6; y++)
        {
            BuildAWall(8, y, wallTextureType);
            BuildAWall(22, y, wallTextureType);
        }
    }

    private void BuildMultipleWallNine(TileContent wallTextureType)
    {
        for(int y=0; y<6; y++)
        {
            BuildAWall(28, y, wallTextureType);
            BuildAWall(25, y, wallTextureType);
            BuildAWall(22, y, wallTextureType);
            BuildAWall(19, y, wallTextureType);
            BuildAWall(16, y, wallTextureType);
            BuildAWall(13, y, wallTextureType);
        }

        for (int y = 9; y < 15; y++)
        {
            BuildAWall(28, y, wallTextureType);
            BuildAWall(25, y, wallTextureType);
            BuildAWall(22, y, wallTextureType);
            BuildAWall(19, y, wallTextureType);
            BuildAWall(16, y, wallTextureType);
            BuildAWall(13, y, wallTextureType);
        }

        for (int x = 0; x < 29; x+=2)
        {
            BuildAWall(x, 16, wallTextureType);
            BuildAWall(x, 18, wallTextureType);
        }

    }
    private void LoadNextLevel()
    {

        // Resets the controller.
        controller.Reset();

        // Set score
        Score = 0;

        // Disable bonus
        bonusActive = false;

        // Clear board
        Board.Reset();

        // Resets snake
        snake.Reset();

        //Level 1
        if (tempScore >= 1 && Level == 0)
        {
            Level = 1;
            tempScore = 0;
            BuildMultipleWallTwo(TileContent.Wall1);
        }
        //Level 2
        else if (tempScore >= 1 && Level == 1)
        {
            Level = 2;
            tempScore = 0;
            BuildMultipleWallThree(TileContent.Wall1);
        }
        else if (tempScore >= 1 && Level == 2)
        {
            Level = 3;
            tempScore = 0;
            BuildMultipleWallFour(TileContent.Wall2);
        }
        else if (tempScore >= 1 && Level == 3)
        {
            Level = 4;
            tempScore = 0;
            BuildMultipleWallFive(TileContent.Wall2);
        }
        else if (tempScore >= 1 && Level == 4)
        {
            Level = 5;
            tempScore = 0;
            BuildMultipleWallSix(TileContent.Wall2);
        }
        else if (tempScore >= 1 && Level == 5)
        {
            Level = 6;
            tempScore = 0;
            BuildMultipleWallSeven(TileContent.Wall3);
        }
        else if (tempScore >= 1 && Level == 6)
        {
            Level = 7;
            tempScore = 0;
            BuildMultipleWallEight(TileContent.Wall3);
        }
        else if (tempScore >= 1 && Level == 7)
        {
            Level = 8;
            tempScore = 0;
            BuildMultipleWallNine(TileContent.Wall3);
        }

        // Plant an apple
        PlantAnApple();
        for (int x = 0; x < 10; x++)
        {
            PlantAPoison();
        }
        // Start bonus coroutine
        PlantABonus();

        Time.timeScale = 1;

        // Start the game
        Paused = false;
        time = 0;
    }

    public void StartNextLevel()
    {
        HideAllPanels();
        LoadNextLevel();
        GamePanel.gameObject.SetActive(true);
    }

	public void AccessToggle()
	{
		if (accessFlag == false)
		{
			accessFlag = true;
			soundManager.StopMainMenu();
		}
		else
		{
			accessFlag = false;
			soundManager.PlayMainMenu();
		}
	}
}
