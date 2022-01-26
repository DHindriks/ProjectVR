using UnityEngine;

public class NpcLookAtPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    [SerializeField]
    [Tooltip("if it is 0 then the npc will always look at the player")]
    private float range = 0;

    private Vector3 targetPoint;

    private Quaternion targetRotation;

    private bool followPlayer = true;

    private Vector3 targetPosition;

    public bool FollowPlayer
    {
        set => followPlayer = value;
        get => followPlayer;
    }

    public Vector3 TargetPosition
    {
        set => targetPosition = value;
        get => targetPosition;
    }

    private void Start()
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (followPlayer)
        {
            targetPosition = player.transform.position;
        }
        FollowTarget(targetPosition);
    }

    private void FollowTarget(Vector3 target)
    {
        float distance = Vector3.Distance(this.transform.position, target);
        if (range != 0 && distance <= range)
        {
            targetPoint = new Vector3(target.x, transform.position.y, target.z) - transform.position;
            targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
    }
}
