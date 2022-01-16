using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BrokenGlass : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The glass manager class")]
    private GlassManager glassManager;

    private Vector3 previousStepperPos = Vector3.zero;

    private void Awake()
    {
        if (glassManager == null)
        {
            glassManager = transform.parent.GetComponent<GlassManager>();
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
