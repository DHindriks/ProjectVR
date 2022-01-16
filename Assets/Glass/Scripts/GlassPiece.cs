using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// Class that handles a piece of broken glass.
/// </summary>
public class GlassPiece : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The glass manager class")]
    private BrokenGlass glassManager;

    private Vector3 previousStepperPos = Vector3.zero;

    private void Awake()
    {
        if (glassManager == null)
        {
            glassManager = transform.parent.GetComponent<BrokenGlass>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position != previousStepperPos)
            {
                glassManager.PlaySoundEffects();
                previousStepperPos = collision.transform.position;
            }
        }
    }
}
