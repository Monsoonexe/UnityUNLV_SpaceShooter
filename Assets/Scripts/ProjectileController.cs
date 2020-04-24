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

    public string owner;

    [Header("---Audio---")]
    public float pitchMin = 1.0f;

    public float pitchMax = 1.8f;

    //member components
    private AudioSource myAudioSource;

    /// <summary>
    /// Use Awake to gather references!
    /// </summary>
    private void Awake()
    {
        //gather references
        myAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Use start to initialize other Components
    /// </summary>
    void Start()
    {
        //Debug.Log("Start");
        //Destroy(this.gameObject, lifeSpan);
    }

    /// <summary>
    /// When a GO gets enabled (like gameObject.SetActive(true);).
    /// </summary>
    private void OnEnable()
    {
        //Debug.Log("OnEnable!");
        myAudioSource.pitch = Random.Range(pitchMin, pitchMax);//pitch shifting!
        //myAudioSource.Play(); - gets interrupted, call in Init() instead.
    }

    /// <summary>
    /// When a GO gets disabled (like gameObject.SetActive(false);).
    /// </summary>
    private void OnDisable()
    {
        //Debug.Log("OnDisable!");
    }

    /// <summary>
    /// Updated gets called every frame.
    /// </summary>
    void Update()
    {
        //move this object along the z-axis (forward)
        //Time.deltaTime is the time between frames.  This is helpful to keep the bullet running
        //at a constant speed (through stutters or computers running at faster frame rate.).
        Vector3 moveVector = transform.forward;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Gets called when a TRIGGER collider collides with another collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name); //print to the console when collision happens.
        //not needed, but useful to see information.

        //if this projectile has collided with it's owner (the object that fired it), then don't kill it
        if (other.CompareTag(owner) || other.CompareTag("SpaceTrash"))
        {
            return;
        }

        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }

    /// <summary>
    ///  Initialize.  Call this when Instantiated to set starting values.
    /// </summary>
    /// <param name="owner">Don't kill the entity that fired this projectile.</param>
    /// <param name="moveSpeed">Different enemies can shoot at different speeds.</param>
    /// <param name="audioClip">Which sound should this projectile play.</param>
    public void Init(string owner, float moveSpeed, AudioClip audioClip)
    {
        //this. pointer is used to differentiate between the "owner" local variable
        //and the "owner" that belongs to this class.
        this.owner = owner;
        this.moveSpeed = moveSpeed;
        myAudioSource.clip = audioClip;//load clip 
        myAudioSource.Play();//play clip
    }
}
