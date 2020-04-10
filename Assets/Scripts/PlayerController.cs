using UnityEngine;

/// <summary>
/// The Player!
/// </summary>
public class PlayerController : RichMonoBehaviour
{
    /// <summary>
    /// The tag the Player object has.
    /// </summary>
    public const string PLAYER_TAG = "Player";

    /// <summary>
    /// How fast does this object move?
    /// </summary>
    private ShipController myShipController;

    //These will be moved to scriptable objects in the future.
    public int score = 0;

    public int lives = 3;

    private void Awake()
    {
        myShipController = gameObject.GetComponent<ShipController>();
    }

    private void OnEnable()
    {
        //subscribe to events
        EventManager.onEnemyDestroyed.AddListener(OnEnemyDestroyed);
    }

    private void OnDisable()
    {
        //unsubscribe to events
        //ALWAYS UNSUBSCRIBE TO EVENTS
        EventManager.onEnemyDestroyed.RemoveListener(OnEnemyDestroyed);
    }

    /// <summary>
    /// Do these things when an enemy has been destroyed.
    /// </summary>
    private void OnEnemyDestroyed()
    {
        score += 10;//ten points to Gryffindor!
        EventManager.onScoreUpdate.Invoke();//ring the bell to update UI.
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();

        DoShooting();
    }

    /// <summary>
    /// Tell ship to shoot.
    /// </summary>
    private void DoShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))//if the space bar was pressed down this frame
        {
            myShipController.Shoot();
        }
    }

    /// <summary>
    /// Tell ship how to move.
    /// </summary>
    private void DoMovement()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);

        //vertical movement
        if (Input.GetKey(KeyCode.A)) // if "a" key is pressed
        {
            //move left
            moveVector += -transform.right;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //Move right
            moveVector += transform.right;
        }

        //Horizontal movement
        if (Input.GetKey(KeyCode.W))
        {
            //Move forward
            moveVector += transform.forward;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            //Move back
            moveVector += -transform.forward;
        }

        myShipController.Move(moveVector);
    }
}
