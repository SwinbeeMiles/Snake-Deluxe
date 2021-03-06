﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Controller : MonoBehaviour
{
    /// <summary>
    /// Last direction that was in the queue.
    /// </summary>
    private IntVector2 _lastDirection;

    /// <summary>
    /// Queue of direction change commands.
    /// </summary>
    public LinkedList<IntVector2> queue;

    /// <summary>
    /// Specyfies snake's current moving direction.
    /// </summary>
    public IntVector2 LastDirection
    {
        get
        {
            if (queue.Count == 0)
                return _lastDirection;

            return queue.Last.Value;
        }
    }

	public IntVector2 GetDirection
	{
		get
		{
			return queue.First.Value;
		}
	}

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("up") && LastDirection != Vector2.down)
        {
            Enqueue(Vector2.up);
        }
        else if (Input.GetKeyDown("down") && LastDirection != Vector2.up)
        {
            Enqueue(Vector2.down);
        }
        else if (Input.GetKeyDown("left") && LastDirection != Vector2.right)
        {
            Enqueue(Vector2.left);
        }
        else if (Input.GetKeyDown("right") && LastDirection != Vector2.left)
        {
            Enqueue(Vector2.right);
        }
    }

    /// <summary>
    /// Enqueues next direction change command.
    /// </summary>
    /// <param name="up"></param>
    public void Enqueue(IntVector2 direction)
    {
		if (direction == Vector2.zero)
		{
	        queue.AddLast(direction);
		}
		else
		{
			queue.AddLast(direction);
	        _lastDirection = direction;
		}
    }

    /// <summary>
    /// Gets next direction and removes it from the command queue.
    /// </summary>
    /// <returns></returns>
    public IntVector2 NextDirection()
    {
        if (queue.Count == 0)
            return _lastDirection;

        var first = queue.First.Value;
        queue.RemoveFirst();

        return first;
    }

	public IntVector2 PreviousDirection()
    {
        return _lastDirection;
    }

	public void Resume()
	{
		queue = new LinkedList<IntVector2>();
		Enqueue(_lastDirection);
	}

    /// <summary>
    /// Resets the controller.
    /// </summary>
    public void Reset()
    {
        queue = new LinkedList<IntVector2>();
        Enqueue(Vector2.up);
    }
}
