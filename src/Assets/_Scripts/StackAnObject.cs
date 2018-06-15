using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackAnObject : MonoBehaviour, IInputHandler
{
    public bool CreateStacksAutomaticallyAtStart = true;

    public int NumberOfStacksToCreate = 10;

	void IInputHandler.OnInputDown(InputEventData eventData)
	{   }

	// Tap for HoloLens, Trigger for controllers
	void IInputHandler.OnInputUp(InputEventData eventData)
    {
        CreateAStack();
    }

    private void CreateAStack()
    {
        var o = GameObject.CreatePrimitive(PrimitiveType.Cube);
        o.transform.localScale = new Vector3(1f, 0.1f, 1f);
        Debug.Log("Posistion: x=" + transform.position.x + ", z=" + transform.position.z);

        //// Gaze position != Controller position
        //o.transform.position = new Vector3(GazeManager.Instance.HitPosition.x, 
        //    10f, 
        //    GazeManager.Instance.HitPosition.z);

        // Gaze position != Controller position
        o.transform.position = new Vector3(0,
            10f,
            4);

        o.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 1f, 1f, 0f, 0.2f);
        o.AddComponent<Rigidbody>();
    }

    // Use this for initialization
    void  Start()
    {
        if (CreateStacksAutomaticallyAtStart)
        {
            for (int i = 0; i < NumberOfStacksToCreate; i++)
            {
                CreateAStack();
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
	{   }
}
