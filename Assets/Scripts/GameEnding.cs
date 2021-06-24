using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup faderCanvas;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    public bool IsPlayerAtExit;
    public bool IsPlayerCaught;
    public float Timer;
    public bool HasAudioPlayed;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        IsPlayerCaught = true;
    }

    private void Update()
    {
        if (IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!HasAudioPlayed)
        {
            audioSource.Play();
            HasAudioPlayed = true;
        }
        Timer += Time.deltaTime;
        imageCanvasGroup.alpha = Timer / fadeDuration;

        if (Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                faderCanvas.interactable = true;
                faderCanvas.blocksRaycasts = true;
            }
            else
            {
                faderCanvas.interactable = true;
                faderCanvas.blocksRaycasts = true;
            }
        }

    }

    public void backToMenu()
    {
        faderCanvas.interactable = false;
        faderCanvas.blocksRaycasts = false;
        SceneManager.LoadScene(0);
    }

}
