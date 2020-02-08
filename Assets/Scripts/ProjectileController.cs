using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    /// <summary>
    /// How fast this projectile moves.
    /// </summary>
    public float moveSpeed = 150;

    /// <summary>
    /// Destroys after this many seconds.
    /// </summary>
    public float lifeSpan = 5;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        Destroy(this.gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
