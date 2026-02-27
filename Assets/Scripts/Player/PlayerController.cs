using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Moving Settings")]
    public float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    //Jumping / Physics
    private Rigidbody playerRb;
    public float jumpforce = 10;
    public float gravityModifer = 1;
    private bool isOnGround = true;

    public float health = 100;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;


    }

    // Update is called once per frame
    void Update()

    {
        Move();
        Jump();


    }
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move the player fowards and backwards
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        //Move the player left and right
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Acceleration);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
