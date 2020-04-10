using UnityEngine;

public class ShipController : RichMonoBehaviour
{
    /// <summary>
    /// Speed of ship
    /// </summary>
    public float moveSpeed = 75;

    /// <summary>
    /// Spawn this object when shooting.
    /// </summary>
    public GameObject projectilePrefab;

    /// <summary>
    /// How fast a projectile fired from this object should move.
    /// </summary>
    public float projectileMoveSpeed = 150.0f;

    /// <summary>
    /// Play this sound clip.
    /// </summary>
    [Header("---Audio---")]
    public AudioClip projectileClip;

    /// <summary>
    /// Fire the ship's weapons.
    /// </summary>
    public void Shoot()
    {
        //get a reference to the newly created projectile object
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //projectile.Awake(), .OnEnable(), and .Start() happen all before program gets here.

        //get a reference to the component that exists on the newly created GO
        ProjectileController projectileController = projectileGO.GetComponent<ProjectileController>();

        //set starting values, like speed and owner
        projectileController.Init(this.gameObject.tag, projectileMoveSpeed, projectileClip);

    }

    /// <summary>
    /// Fire the ship's thrusters and move the ship.
    /// </summary>
    /// <param name="moveVector"></param>
    public void Move(Vector3 moveVector)
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World); // decrease x-value
    }
}
