using UnityEngine;

/// <summary>
/// This will be expanded to include movement behavior
/// </summary>
public class EnemyController : RichMonoBehaviour
{
    [Header("---Attack---")]
    [SerializeField]
    private Vector2 shootDelay = new Vector2(1f, 3f);

    private float nextShootTime = 0;

    //member components
    private ShipController myShipController;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        myShipController = gameObject.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();

        DoShooting();
        
    }

    /// <summary>
    /// Probably Destroyed by a Projectile.
    /// </summary>
    private void OnDestroy()
    {
        //alert anybody who is listening that an enemy has been destroyed.
        EventManager.onEnemyDestroyed.Invoke();
    }

    /// <summary>
    /// This ship has collided with something.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //kill player if collided.
        if (other.CompareTag(PlayerController.PLAYER_TAG))
        {
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// Tell ship to move.
    /// </summary>
    private void DoMovement()
    {
        Vector3 moveVector = transform.forward;

        myShipController.Move(moveVector);
    }

    /// <summary>
    /// Tell the ship to shoot.
    /// </summary>
    private void DoShooting()
    {
        if(Time.time >= nextShootTime)//cooldown
        {
            myShipController.Shoot();//pull trigger
            //update delay
            nextShootTime = Time.time + Random.Range(shootDelay.x, shootDelay.y);
        }
    }
}
