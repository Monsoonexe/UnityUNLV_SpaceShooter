using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : RichMonoBehaviour
{
    [SerializeField]
    private GameObject pickupPrefab;

    private GameObject pickupInstance;

    private void Awake()
    {
        pickupInstance = Instantiate(
            pickupPrefab,//what
            transform.position,//where
            Quaternion.identity);//orientation

        pickupInstance.SetActive(false);
    }

    private void OnDestroy()
    {
        if (pickupInstance != null)
        {
            pickupInstance.SetActive(true);

            pickupInstance.transform.position = this.transform.position;
        }
    }
}
