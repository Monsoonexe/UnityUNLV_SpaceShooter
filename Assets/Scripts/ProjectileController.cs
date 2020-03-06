using UnityEngine;

public class ProjectileController : RichMonoBehaviour
{
    /// <summary>
    /// How fast this projectile moves.
    /// </summary>
    public float moveSpeed = 150;

    /// <summary>
    /// Destroys after this many seconds.
    /// </summary>
    public float lifeSpan = 5;

    public GameObject owner;

    [Header("---Audio---")]
    public float pitchMin = 1.0f;

    public float pitchMax = 1.8f;

    //member components
    private AudioSource myAudioSource;

    private void Awake()
    {
        //gather references
        myAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        //Debug.Log("Start");
        //Destroy(this.gameObject, lifeSpan);
    }

    private void OnEnable()
    {
        //Debug.Log("OnEnable!");
        myAudioSource.pitch = Random.Range(pitchMin, pitchMax);
        //myAudioSource.Play(); - gets interrupted
    }

    private void OnDisable()
    {
        //Debug.Log("OnDisable!");

    }

    // Update is called once per frame
    void Update()
    {
        //move this object along the z-axis (forward)
        //Time.deltaTime is the time between frames.  This is helpful to keep the bullet running
        //at a constant speed (through stutters or computers running at faster frame rate.).
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); //print to the console when collision happens.
        //not needed, but useful to see information.

        //if this projectile has collided with it's owner (the object that fired it), then don't kill it
        if (other.gameObject == owner)
        {
            return;
        }

        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }

    /// <summary>
    /// Initialize.  Call this when Instantiated to set starting values.
    /// </summary>
    public void Init(GameObject owner, float moveSpeed, AudioClip audioClip)
    {
        //this. pointer is used to differentiate between the "owner" local variable
        //and the "owner" that belongs to this class.
        this.owner = owner;
        this.moveSpeed = moveSpeed;
        myAudioSource.clip = audioClip;
        myAudioSource.Play();
        
    }
}
