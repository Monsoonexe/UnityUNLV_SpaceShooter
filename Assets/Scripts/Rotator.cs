using UnityEngine;

public class Rotator : RichMonoBehaviour
{
    public Vector3 rotationVector;

    private void Start()
    {
        GetRandomRotationVector(ref rotationVector);
    }

    private void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    public static void GetRandomRotationVector(ref Vector3 rotationVector)
    {
        rotationVector.x = Random.Range(3, 16);
        rotationVector.y = Random.Range(3, 16);
        rotationVector.z = Random.Range(3, 16);
    }
}
