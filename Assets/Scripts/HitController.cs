using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HitTrigger");
        Debug.Log(other.transform.GetChild(1).name);
        Debug.Log(other.transform.GetChild(2).name);
        if (!other.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        
        if (other.transform.GetChild(2).TryGetComponent(out Radar radar) == true)
        {
            radar.ball_state_type = Radar.BALL_STATE_TYPE.EMPTY;
            radar.transform.SetParent(null);
            Debug.Log("ì˜óéÇ∆Çµê¨å˜ÅI");
        }

    }
}
