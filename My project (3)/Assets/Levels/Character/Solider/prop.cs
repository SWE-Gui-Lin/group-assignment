using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop : MonoBehaviour
{
    public int Keycount;
    public static class Constants
{
    public const string TAG_KEY = "Key";
}
    // Start is called before the first frame update
    public bool PickupItem(GameObject obj)
    {
        switch(obj.tag)
        {
            case Constants.TAG_KEY:
            PickUpKey();
            return true;

            default:
            Debug.Log("can not pick up");
            return false;
        }
    }
    private void PickUpKey()
    {
        Keycount++;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
