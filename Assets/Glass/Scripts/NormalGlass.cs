using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles a whole glass when it's not broken.
/// </summary>
public class NormalGlass : MonoBehaviour
{
    [SerializeField]
    private GameObject glassPanePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(glassPanePrefab, this.transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);
    }
}
