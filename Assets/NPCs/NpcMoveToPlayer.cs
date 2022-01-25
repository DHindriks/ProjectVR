using UnityEngine;

public class NpcMoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool goesBack = true;

    [SerializeField]
    private float speed = 0.2f;

    [SerializeField]
    private float searchRange = 2f;

    private bool followPlayer = false;

    private bool stopped = false;

    private Vector3 initialPosition;

    float distanceNpcToStart = 0;

    float distanceNpcToPlayer = 0;

    float distanceStartToPlayer = 0;

    NpcLookAtPlayer npcLookAtPlayer;
    private void Start()
    {
        initialPosition = this.transform.position;
        npcLookAtPlayer = this.GetComponent<NpcLookAtPlayer>();
    }


    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        //The distance between start point and player.
        distanceNpcToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (distanceNpcToPlayer <= 0.8f)
        {
            stopped = true;
            Debug.Log(distanceNpcToPlayer);
            PlayAnimation("Idle");
        }
        else
        {
            stopped = false;
        }

        distanceStartToPlayer = Vector3.Distance(initialPosition, player.transform.position);
        if (distanceStartToPlayer <= searchRange)
        {
            followPlayer = true;
            npcLookAtPlayer.FollowPlayer = true;
        }
        else
        {
            followPlayer = false;
        }

        if (followPlayer && !stopped)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
            distanceNpcToStart = Vector3.Distance(this.transform.position, initialPosition);
            PlayAnimation("Walk");

            if (distanceNpcToStart >= searchRange)
            {
                followPlayer = false;
            }
        }
        else if(goesBack && !stopped)
        {
            if (distanceNpcToStart >= 0.2f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, initialPosition, speed * Time.fixedDeltaTime);
                distanceNpcToStart = Vector3.Distance(this.transform.position, initialPosition);
                PlayAnimation("Walk");

            }
            else
            {
                PlayAnimation("Idle");
            }
            if (npcLookAtPlayer != null)
            {
                LookToInitialPosition();
            }
        }
    }

    private void LookToInitialPosition()
    {
        npcLookAtPlayer.FollowPlayer = false;
        npcLookAtPlayer.TargetPosition = initialPosition;
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
