using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLights : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Color[] colors;

    [SerializeField]
    private float frecuency;

    private int index = 0;
    private float timer = 0;

    void Start()
    {
        index = Random.Range(0, colors.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        if(timer > frecuency)
        {
            if (index >= colors.Length)
            {
                index = 0;
            }
            this.GetComponent<Light>().color = colors[index];
            index++;
            timer = 0;
        }
    }
}
