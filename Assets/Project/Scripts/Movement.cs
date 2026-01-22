using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mvSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private Vector2 mvInput;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mvInput.x = Input.GetAxisRaw("Horizontal");
        mvInput.y = Input.GetAxisRaw("Vertical");
        mvInput = mvInput.normalized;

        anim.SetBool("IsRunning", mvInput != Vector2.zero);

        if(mvInput.x < 0)
            sprite.flipX = true;
        else if(mvInput.x > 0)
            sprite.flipX = false;
    }
    void FixedUpdate(){
        rb.linearVelocity = mvInput * mvSpeed;
    }
}
