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

	public void PlayRightBeepSoundEffect()
	{
		if (rightBeepSource != null)
		{
			rightBeepSource.Play();
		}
	}

	public void PlayCenterBeepSoundEffect()
	{
		if (centerBeepSource != null)
		{
			centerBeepSource.Play();
		}
	}

    // Update is called once per frame
    void Update()
    {

    }
}
