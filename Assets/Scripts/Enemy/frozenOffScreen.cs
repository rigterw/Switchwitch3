using UnityEngine;

public class frozenOffScreen : MonoBehaviour
{
    [SerializeField] bool hasRotation;//bool if the object should be able to rotate after unfreezing
    Rigidbody2D rb;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if object is close enough to player to unfreeze
        if(transform.position.x - player.position.x < 13 )
            rb.constraints = hasRotation ? RigidbodyConstraints2D.None : RigidbodyConstraints2D.FreezeRotation;
    }
}
