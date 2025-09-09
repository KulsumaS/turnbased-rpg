using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movespeed;// allows us to controll the speed of the player
    public Vector3 playerMoveDirection;

    // Update is called once per frame
    void Update()
    {//get x an y values, it will always be either +1,-1 or 0
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerMoveDirection = new Vector2(inputX,inputY).normalized;
         // wants it in a vector format, sets horizontal and vertical forces
    }

    void FixedUpdate() // Ensure that the framerate of different devices do not effect the velocity of the player
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * movespeed,
                playerMoveDirection.y * movespeed);
    }
}
  