using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGlass : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Possible audio clips for the broken glass")]
    private List<AudioClip> sounds;

    [SerializeField]
    [Tooltip("The audio source")]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject glassPanePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(glassPanePrefab, this.transform.position, this.transform.rotation);
        PlayClip();
        this.gameObject.SetActive(false);
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
