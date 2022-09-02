using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour
{
    public Transform playerA;
    public Transform playerB;

    public float distance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player A magnitude is: " + Vector3.Magnitude(playerA.position));
        Debug.Log("Player B magnitude is: " + Vector3.Magnitude(playerB.position));

        distance = Vector3.Distance(playerA.position, playerB.position);

        StartCoroutine("TargetPlayerCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Distance between players is: " + Vector3.Distance(playerA.position, playerB.position));
        distance = Vector3.Distance(playerA.position, playerB.position);

        if (distance < 2)
        {
            playerA.gameObject.SetActive(false);
        }
        else
        {
            playerA.gameObject.SetActive(true);
        }

        Debug.Log("Cross Product is: " + Vector3.Cross(playerA.position, playerB.position));
        Debug.Log("Dot Product is: " + Vector3.Dot(playerA.position, playerB.position));

        
    }

    IEnumerator TargetPlayerCoroutine()
    {
        //Works
        while (distance > 0.03f)
        {
            playerB.position = Vector3.Lerp(playerB.position, playerA.position, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        //Ends
    }
}
