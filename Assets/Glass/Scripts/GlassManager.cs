using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    [Tooltip("The Possible audio clips for the broken glass")]
    private List<AudioClip> sounds;

    [SerializeField]
    [Tooltip("The audio source")]
    private AudioSource audioSource;

    [SerializeField]
    [Tooltip("The waiting time between replaying the sound")]
    private float waitTime = 0.5f;

    [SerializeField]
    [Tooltip("Wether or not the sound should be when stepped over")]
    private bool enableStepSound = true;

    static private bool soundPlaying = false;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlaySoundEffects()
    {
        Debug.LogError(soundPlaying);
        if (!soundPlaying && enableStepSound)
        {
            soundPlaying = true;
            PlayClip();
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

    public void PlayClip()
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
