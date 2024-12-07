using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip SFX;//音效
    public GameObject VFX;//特效
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PropManager manager = collision.GetComponent<PropManager>();
        if(manager)
        {
            bool pickedUp = manager.PickupItem(gameObject);
            if(pickedUp)
            {
                RemoveItem();
            }
        }
    }
    private void RemoveItem()
    {
        AudioSource.PlayClipAtPoint(SFX,transform.position);
        Instantiate(VFX,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
