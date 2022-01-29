using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject treeToSpawn;

    [Space(5)]
    [Header("Children")]
    [SerializeField]
    private Transform dynamicChildren;
    [SerializeField]
    private Transform road;
    [SerializeField]
    private Transform endMarker;

    [Space(5)]
    [Header("Level Info")]
    [SerializeField]
    private float roadLength = 20;

    [Space(5)]
    [Header("Audio")]
    [SerializeField]
    private float trackLengthInSeconds;
    [SerializeField]
    private int trackBPM;

    void Awake()
    {
        dynamicChildren.GetComponent<Scrolling>().Init(trackLengthInSeconds, roadLength);
    }

    void Start()
    {
        road.localScale = new Vector3(roadLength, 1, 1);
        road.localPosition = Vector3.right * roadLength * 5;
        endMarker.localPosition = Vector3.right * roadLength * 10;
        float poleIntervals = ((roadLength * 10) / trackLengthInSeconds) * (60.0f/(float)trackBPM); // scroll speed (units/s) * # of s / beat
        for (int i = 0; i < (int) ((trackLengthInSeconds/60.0f) * trackBPM); i++){
            Debug.Log(i);
            Instantiate(treeToSpawn, new Vector3(i * poleIntervals, 2, 4), Quaternion.identity, dynamicChildren);
        }
    }

}
