using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectorEnemyController : RichMonoBehaviour
{
    [Header("---RepairStuff---")]
    [SerializeField]
    private float repairTime = 1.0f;

    [SerializeField]
    private float repairSpawnDistance = 5;

    [SerializeField]
    private GameObject basicShipPrefab;

    private bool isRepairing = false;

    [Header("---Attack---")]
    [SerializeField]
    private Vector2 shootDelay = new Vector2(1f, 3f);

    private float nextShootTime = 0;

    private Transform targetPickup;

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

        //DoShooting();
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
        else if(other.CompareTag("SpaceTrash"))
        {
            Destroy(other.gameObject);
            StartCoroutine(RepairShip());
        }
    }

    private IEnumerator RepairShip()
    {
        //
        isRepairing = true;//don't move while repairing

        yield return new WaitForSeconds(repairTime);

        //resurrect the dead ship
        GameObject resurrectedShip = Instantiate(basicShipPrefab);

        //position ship slightly ahead so no overlap with resurrector
        Vector3 spawnPoint = transform.position + transform.forward * repairSpawnDistance;

        //position it
        resurrectedShip.transform.position = spawnPoint;
        resurrectedShip.transform.Rotate(0f, 180f, 0f);//face down towards player
        
        isRepairing = false;
    }

    private Transform FindNewTarget()
    {
        //pick closest one
        GameObject[] everyPickup = GameObject.FindGameObjectsWithTag("SpaceTrash");

        //no pickups found
        if (everyPickup.Length == 0) return null;

        int closestDistance = int.MaxValue;
        int indexOfClosest = 0;

        if (everyPickup.Length > 0)
        {
            //find closest pickup
            for (int i = 0; i < everyPickup.Length; ++i)
            {
                if (Vector3.Distance(transform.position, everyPickup[i].transform.position) <
                    closestDistance)
                {
                    indexOfClosest = i;
                }
            }
        }

        return everyPickup[indexOfClosest].transform;
    }

    /// <summary>
    /// Tell ship to move.
    /// </summary>
    private void DoMovement()
    {
        //no movement if repairing
        if (isRepairing) return;

        //if we have no target, find one
        if (targetPickup == null)
        {
            targetPickup = FindNewTarget();

        }

        Vector3 moveVector = Vector3.zero;

        if (targetPickup)// if there is a target
        {
            this.transform.LookAt(targetPickup.transform);
            moveVector = transform.forward;//move forward
        }

        myShipController.Move(moveVector);
    }

    /// <summary>
    /// Tell the ship to shoot.
    /// </summary>
    private void DoShooting()
    {
        if (Time.time >= nextShootTime)//cooldown
        {
            myShipController.Shoot();//pull trigger
            //update delay
            nextShootTime = Time.time + Random.Range(shootDelay.x, shootDelay.y);
        }
    }
}
