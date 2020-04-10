using UnityEngine;

public class EnemyManager : RichMonoBehaviour
{
    [Header("---Collections---")]
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private Transform[] spawnPoints;

    [Header("---Spawn Stuff---")]
    [SerializeField]
    private Vector2 spawnDelay = new Vector2(1, 3);

    private float nextSpawnTime = 0;

    [SerializeField]
    private int numberOfEnemies = 0;

    [SerializeField]
    private int maxNumberEnemiesAllowed = 10;
    
    private void OnEnable()
    {
        //subscribe to event
        EventManager.onEnemyDestroyed.AddListener(OnEnemyDestroyed);
    }

    private void OnDisable()
    {
        //unsubscribe if shut down. (not really needed, but good pratice)
        EventManager.onEnemyDestroyed.RemoveListener(OnEnemyDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        DoSpawnEnemy();
    }

    /// <summary>
    /// React to an enemy being destroyed.
    /// </summary>
    private void OnEnemyDestroyed()
    {
        --numberOfEnemies;// enemies - 1
    }

    /// <summary>
    /// Spawn and init an enemy from prefabs list and place it at random spawn point.
    /// </summary>
    public void SpawnEnemy()
    {
        //pick a random ennemy to spawn
        GameObject randomEnemy = GetRandomElement(enemyPrefabs);

        //pick a random spawn point
        Transform randomSpawnPoint = GetRandomElement(spawnPoints);

        //actually spawn it
        GameObject newEnemy = Instantiate(
            randomEnemy, //spawn what
            randomSpawnPoint.position, //spawn where
            transform.rotation);//with what orientation

        //init enemy
        //not needed yet.
    }

    /// <summary>
    /// 
    /// </summary>
    private void DoSpawnEnemy()
    {
        if(Time.time > nextSpawnTime)//is it time to spawn a new enemy yet
        {
            if(numberOfEnemies < maxNumberEnemiesAllowed)//is there room to spawn a new enemy
            {
                SpawnEnemy();//spawn it.

                //update next spawn time
                nextSpawnTime = Time.time + Random.Range(spawnDelay.x, spawnDelay.y);

                ++numberOfEnemies;//keep track of how many are in scene

            }
        }

        //adjust cooldown
    }

    /// <summary>
    /// Generic function to get a random element from any array.
    /// </summary>
    /// <returns>Array[RandomIndex]</returns>
    public static T GetRandomElement<T>(T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

}
