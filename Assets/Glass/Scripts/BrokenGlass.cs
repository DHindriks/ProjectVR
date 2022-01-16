using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles a glass when broken
/// </summary>
public class BrokenGlass : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    [Tooltip("The Possible audio clips for the glass is getting stepped over")]
    private List<AudioClip> steppingClips;

    [SerializeField]
    [Tooltip("The Possible audio clips for when the glass is breaking")]
    private List<AudioClip> breakingClips;

    [SerializeField]
    [Tooltip("The audio source")]
    private AudioSource audioSource;

    [SerializeField]
    [Tooltip("The waiting time between replaying the sound")]
    private float waitTime = 0.8f;

    [SerializeField]
    [Tooltip("Wether or not the sound should be when stepped over")]
    private bool enableStepSound = true;

    [SerializeField]
    [Tooltip("Wether or not the sound should be when stepped over")]
    private bool playSoundOnStart = true;

    static private bool soundPlaying = false;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (playSoundOnStart)
            PlayClip(breakingClips);
    }

    public void PlaySoundEffects()
    {
        if (!soundPlaying && enableStepSound)
        {
            soundPlaying = true;
            PlayClip(steppingClips);
            StartCoroutine(WaitForSoundEnd());
        }
    }

    private IEnumerator WaitForSoundEnd()
    {
        yield return new WaitForSeconds(waitTime);
        soundPlaying = false;
    }

    public void OnTriggerGlass()
    {
        PlaySoundEffects();
    }

    public void PlayClip(List<AudioClip> sounds)
    {
        if (sounds.Count > 0)
        {
            int audioClipNumber = Random.Range(0, sounds.Count);
            float newPitch = Random.Range(0.6f, 1f);
            audioSource.pitch = newPitch;
            audioSource.PlayOneShot(sounds[audioClipNumber]);
        }
    }
}
