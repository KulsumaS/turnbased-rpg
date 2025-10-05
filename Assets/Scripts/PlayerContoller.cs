using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    public Animator anim;
    
    [SerializeField] private Rigidbody2D rb;
   
    public float x;
    public float y;
    public float movespeed;// allows us to controll the speed of the player
    public Vector2 playerMoveDirection;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   
    
// Update is called once per frame
    private void Update()
    {
        GetInput();
        Animate();
    }

    
    private void GetInput()
    {//get x an y values, it will always be either +1,-1 or 0
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        playerMoveDirection = new Vector2(x,y).normalized;
         // wants it in a vector format, sets horizontal and vertical forces
    }

    void FixedUpdate() // Ensure that the framerate of different devices do not effect the velocity of the player
    {
        rb.linearVelocity = new Vector3(playerMoveDirection.x * movespeed,
                playerMoveDirection.y * movespeed);
    }

    private void Animate()
    {
        if(playerMoveDirection.magnitude > 0.1f ) //if the the input is grster than one or less than then movemnt is true
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        
        anim.SetBool("Moving", moving);
        
        if (moving)
        {
            anim.SetFloat("X", Input.GetAxis("Horizontal"));
            anim.SetFloat("Y", Input.GetAxis("Vertical"));

        }
        
    }
    
} 
  