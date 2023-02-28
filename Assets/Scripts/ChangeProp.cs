using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeProp : MonoBehaviour
{
    [SerializeField] private float activateDistance = 10f;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Transform propSize;

    void Update()
    {
        RaycastHit hit;
        Ray changeProp = new Ray(transform.position, transform.forward);

        // Send raycast
        if(Physics.Raycast(changeProp, out hit, activateDistance))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "AllowedProp")
            {
                Mesh mesh = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;

                // Update mesh
                if (mesh != null)
                {
                    meshFilter.mesh = mesh;
                }

                // Change material
                meshRenderer.material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;

                // Update object scale
                propSize.localScale = hit.transform.localScale;
            }
        }
    }
}
