using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Audio clip that will be played when snake collects an apple.
    /// </summary>
    public AudioClip AppleClip;

    /// <summary>
    /// Audio clip that will be played when snake collects a bonus.
    /// </summary>
    public AudioClip BonusClip;

    /// <summary>
    /// Audio clip that will be played when game is over.
    /// </summary>
    public AudioClip GameOverClip;

	public AudioClip LeftBeepClip;

	public AudioClip CenterBeepClip;

	public AudioClip RightBeepClip;

	public AudioClip MainMenuClip;

	public AudioClip PauseClip;

	public AudioClip GameOverSpeechClip;

	public AudioClip LeftTickClip;

	public AudioClip RightTickClip;

	public AudioClip AlertClip;

    /// <summary>
    /// Audio source for an apple sound clip.
    /// </summary>
    private AudioSource appleAudioSource;

    /// <summary>
    /// Audio source for a bonus sound clip.
    /// </summary>
    private AudioSource bonusAudioSource;

    /// <summary>
    /// Audio source for a game over sound clip.
    /// </summary>
    private AudioSource gameOverAudioSource;

	private AudioSource leftBeepSource;

	private AudioSource centerBeepSource;

	private AudioSource rightBeepSource;

	private AudioSource MainMenuSource;

	private AudioSource PauseSource;

	private AudioSource GameOverSpeechSource;

	private AudioSource leftTickSource;

	private AudioSource rightTickSource;

	private AudioSource alertSource;

    // Use this for initialization
    void Awake()
    {
        if (AppleClip != null)
        {
            appleAudioSource = gameObject.AddAudio(AppleClip, false, false, 1f);
        }
        if (BonusClip != null)
        {
            bonusAudioSource = gameObject.AddAudio(BonusClip, false, false, 1f);
        }
        if (GameOverClip != null)
        {
            gameOverAudioSource = gameObject.AddAudio(GameOverClip, false, false, 1f);
        }
		if (LeftBeepClip != null)
		{
			leftBeepSource = gameObject.AddAudio(LeftBeepClip, false, false, 1f);
		}
		if (RightBeepClip != null)
		{
			rightBeepSource = gameObject.AddAudio(RightBeepClip, false, false, 1f);
		}
		if (CenterBeepClip != null)
		{
			centerBeepSource = gameObject.AddAudio(CenterBeepClip, false, false, 1f);
		}
		if (LeftTickClip != null)
		{
			leftTickSource = gameObject.AddAudio(LeftTickClip, false, false, 1f);
		}
		if (RightTickClip != null)
		{
			rightTickSource = gameObject.AddAudio(RightTickClip, false, false, 1f);
		}
		if (MainMenuClip != null)
		{
			MainMenuSource = gameObject.AddAudio(MainMenuClip, false, false, 1f);
		}
		if (PauseClip != null)
		{
			PauseSource = gameObject.AddAudio(PauseClip, false, false, 1f);
		}
		if (GameOverSpeechClip != null)
		{
			GameOverSpeechSource = gameObject.AddAudio(GameOverSpeechClip, false, false, 1f);
		}
		if (AlertClip != null)
		{ 
			alertSource = gameObject.AddAudio(AlertClip, false, false, 1f);
		}
    }

    public void PlayAppleSoundEffect()
    {
        if (appleAudioSource != null)
        {
            appleAudioSource.Play();
        }
    }

    public void PlayBonusSoundEffect()
    {
        if (bonusAudioSource != null)
        {
            bonusAudioSource.Play();
        }
    }

    public void PlayGameOverSoundEffect()
    {
        if (gameOverAudioSource != null)
        {
            gameOverAudioSource.Play();
        }
    }

	public void PlayLeftBeepSoundEffect()
	{
		if (leftBeepSource != null)
		{
			leftBeepSource.Play();
		}
	}

	public void PlayLeftTickSoundEffect()
	{
		if (leftTickSource != null)
		{
			leftTickSource.Play();
		}
	}

	public void PlayRightBeepSoundEffect()
	{
		if (rightBeepSource != null)
		{
			rightBeepSource.Play();
		}
	}

	public void PlayRightTickSoundEffect()
	{
		if (rightTickSource != null)
		{
			rightTickSource.Play();
		}
	}

	public void PlayCenterBeepSoundEffect()
	{
		if (centerBeepSource != null)
		{
			centerBeepSource.Play();
		}
	}

	public void PlayMainMenu()
	{
		if (MainMenuSource != null)
		{
			MainMenuSource.Play();
		}
	}

	public void StopMainMenu()
	{
		if (MainMenuSource != null)
		{
			MainMenuSource.Stop();
		}
	}

	public void PlayPause()
	{
		if (PauseSource != null)
		{
			PauseSource.Play();
		}
	}

	public void StopPause()
	{
		if (PauseSource != null)
		{
			PauseSource.Stop();
		}
	}

	public void PlayGameOver()
	{
		if (GameOverSpeechSource != null)
		{
			GameOverSpeechSource.Play();
		}
	}

	public void StopGameOver()
	{
		if (GameOverSpeechSource != null)
		{
			GameOverSpeechSource.Stop();
		}
	}

	public void PlayAlert()
	{
		if (alertSource != null)
		{
			alertSource.Play();
		}
	}

    // Update is called once per frame
    void Update()
    {

    }
}
