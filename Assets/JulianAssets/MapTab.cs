using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTab : MonoBehaviour
{
    public GameObject kitchen;
    private Vector3 miniPosition;
    public float miniSize;

    public Vector3 bigPosition;
    public float bigSize;

    public Vector3 goalPosition;
    public float goalSize;

    public float journeyLength;
    public float speed = 1f;
    public float startTime;
    public int state;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        miniPosition = kitchen.transform.position + new Vector3(0, 0, -23);
        transform.position = miniPosition;
        goalPosition = miniPosition;
        goalSize = miniSize;
        journeyLength = Vector3.Distance(miniPosition, bigPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (state == 0)
            {
                state = 1;
                goalPosition = bigPosition;
                goalSize = bigSize;
                startTime = Time.time;
            }
            else
            {
                state = 0;
                goalPosition = miniPosition;
                goalSize = miniSize;
                startTime = Time.time;
            }
        }
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        
        transform.position = Vector3.Lerp(transform.position, goalPosition, fractionOfJourney);

        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, goalSize, fractionOfJourney);
    }
}
