﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Collider))]
public class ButtonPlatformController : MonoBehaviour {

    Collider col;

    [SerializeField]
    GameObject Platform;
    [SerializeField]
    Vector3 PlatformTargetPos;
    [SerializeField]
    float PlatformMovementTime;

    // Use this for initialization
    void Start ()
    {
        col = GetComponent<Collider>();
	}
	

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        StartCoroutine(MoveOverSeconds(Platform,PlatformTargetPos,PlatformMovementTime));
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
