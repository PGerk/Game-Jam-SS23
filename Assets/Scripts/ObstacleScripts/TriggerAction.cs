using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    private IAction scriptToActivate;

    [Header("Activate Once")]
    public bool activateOnceAfterDelay;
    public float delay;
    [Header("Activate at timed intervals")]
    public bool activateAtTimedIntervals;
    public float interval;
    [Header("Activate on Trigger enter")]
    public bool activateOnTriggerEnter;
    [Header("Activate on Collision")]
    public bool activateOnCollision;
    [Header("THIS SHIT IS VOLATILE AS FUCK SINCE UNITY DOES NOT LIKE INTERFACES")]
    [Header("MAKE SURE THE SCRIPT IMPLEMENTS IACTION")]
    [Header("LEAVE EMPTY TO AUTOMATICALLY FIND SCRIPT")]
    public bool customIactionScript;
    [Tooltip("PROCEED WITH MOTHERFUCKING CAUTION")]
    public Object iActionScript;


    // Start is called before the first frame update
    void Start()
    {
        if (customIactionScript)
        {
            scriptToActivate = (IAction)iActionScript;
}
        else
        {
            scriptToActivate = GetComponent<IAction>();
        }

        if (activateOnceAfterDelay)
        {
            StartCoroutine(ActivateOnceAfterDelay(delay));
        }
        if (activateAtTimedIntervals)
        {
            StartCoroutine(ActivateAtTimedIntervals(interval));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActivateOnceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        scriptToActivate.Action();
    }

    IEnumerator ActivateAtTimedIntervals(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            scriptToActivate.Action();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activateOnCollision)
        {
            scriptToActivate.Action();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activateOnTriggerEnter)
        {
            scriptToActivate.Action();
        }
    }
}
