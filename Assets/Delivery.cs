using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float delayForDestroy = 2f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ai lovit");
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        /* if (the thing we trigger is the package)
        {
            then print "package pricked up" to the console
        }
        */
        if (other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("You picked the package");
            hasPackage = true;
            Destroy(other.gameObject, delayForDestroy);
            spriteRenderer.color = hasPackageColor;
        }
        else
        if(other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
