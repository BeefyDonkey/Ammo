using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] AmmoType ammoType;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ammoCollectSFX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
            audioSource.PlayOneShot(ammoCollectSFX);
            DisableAllMeshes();
            Destroy(this.gameObject, 0.6f);
        }
    }

    private void DisableAllMeshes()
    {
        Component[] meshes;

        meshes = GetComponentsInChildren<MeshRenderer>();

        foreach (var mesh in meshes)
        {
            mesh.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
