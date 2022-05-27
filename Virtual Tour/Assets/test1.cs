using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    public Transform destination;
    float a = 10f;

    // this.transform.position = new Vector3 (Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime*helpCameraFollowFaster),
//                                               Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.deltaTime*helpCameraFollowFaster),0);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, destination.transform.position.x, Time.deltaTime * a), Mathf.Lerp(transform.position.y, destination.transform.position.y, Time.deltaTime * a), Mathf.Lerp(transform.position.z, destination.transform.position.z, Time.deltaTime * a));
    }
}
