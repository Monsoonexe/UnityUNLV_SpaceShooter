using UnityEngine;

/// <summary>
/// This will be expanded to include movement behavior
/// </summary>
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Probably Destroyed by a Projectile.
    /// </summary>
    private void OnDestroy()
    {
        //alert anybody who is listening that an enemy has been destroyed.
        EventManager.onEnemyDestroyed.Invoke();
    }
}
