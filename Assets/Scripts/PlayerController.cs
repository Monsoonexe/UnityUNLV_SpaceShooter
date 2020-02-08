using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;

    public GameObject projectilePrefab;

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
        if (Input.GetKeyDown(KeyCode.Space))//the single fram the button was pressed
        {
            //
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

    }

    private void DoMovement()
    {
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

        else if (Input.GetKey(KeyCode.W))
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
