using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NpcAgent : MonoBehaviour
{
    private Vector3 npcDestination;

    private NavMeshAgent theAgent;

    private float xPos;
    private float zPos;

    private float timer = 0;

    private bool stopped = false;

    private bool destinationSet = false;

    [SerializeField]
    private float changeTime = 3f;

    [SerializeField]
    private float movementRange = 5f;

    private float distanceNpcToDestination = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDestination();
        theAgent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        float distanceToTarget = Vector3.Distance(transform.position, npcDestination);

        if (timer >= changeTime)
        {
            destinationSet = false;
            ChangeDestination();
            stopped = false;
        }

        if (!stopped && !destinationSet)
        {
            theAgent.SetDestination(npcDestination);
            destinationSet = true;
            PlayAnimation("Walk");
        }

        distanceNpcToDestination = Vector3.Distance(this.transform.position, npcDestination);
        if (distanceNpcToDestination <= 0.3f)
        {
            stopped = true;
            PlayAnimation("Idle");
        }
    }

    private void ChangeDestination()
    {
        xPos = this.transform.position.x + GetRandomValue(movementRange);
        zPos = this.transform.position.z + GetRandomValue(movementRange);
        npcDestination = new Vector3(xPos, this.transform.position.y, zPos);
    }

    private float GetRandomValue(float range)
    {
        if(0==(Random.Range(0, 2)))
        {
            return Random.Range(1, range);
        }
        else
        {
            return Random.Range(-1, -range);
        }
    }

    private void PlayAnimation(string animationName)
    {
        Animator animator = this.GetComponent<Animator>();
        if (animator != null)
        {
            this.GetComponent<Animator>().Play(animationName);
        }
    }
}

