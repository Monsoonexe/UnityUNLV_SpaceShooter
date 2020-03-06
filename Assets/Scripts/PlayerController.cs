using UnityEngine;

/// <summary>
/// The Player!
/// </summary>
public class PlayerController : RichMonoBehaviour
{
    /// <summary>
    /// How fast does this object move?
    /// </summary>
    [Header("Player Controller")] // leaves a bold header in the Inspector
    public float moveSpeed = 5;

    public GameObject projectilePrefab;

    public int score = 0;

    public int lives = 3;

    /// <summary>
    /// How fast a projectile fired from this object should move.
    /// </summary>
    public float projectileMoveSpeed = 150.0f;

    [Header("---Audio---")]
    public AudioClip projectileClip;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();

        DoShooting();
    }

    private void DoShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))//if the space bar was pressed down this frame
        {
            //get a reference to the newly created projectile object
            GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //projectile.awake(), .ONenable(), and .start().

            //get a reference to the component that exists on the newly created GO
            ProjectileController projectileController = projectileGO.GetComponent<ProjectileController>();

            //set starting values, like speed and owner
            projectileController.Init(this.gameObject, projectileMoveSpeed, projectileClip);
        }
    }

    private void DoMovement()
    {
        //vertical movement
        if (Input.GetKey(KeyCode.A)) // if "a" key is pressed
        {
            //move left
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0); // decrease x-value
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //Move right
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

        //Horizontal movement
        if (Input.GetKey(KeyCode.W))
        {
            //Move forward
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            //Move back
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        }
    }
}
