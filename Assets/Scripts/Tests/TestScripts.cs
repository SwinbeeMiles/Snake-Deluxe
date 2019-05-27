using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils;

namespace Tests
{
    public class TestScripts
    {
        [Test]
        public void ControllerEnqueueUp()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.up);

			IntVector2 actualdir = controller.NextDirection();
			IntVector2 expecteddir = Vector2.up;

			Assert.AreEqual(actualdir, expecteddir);
        }
		[Test]
        public void ControllerEnqueueRight()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.right);

			controller.NextDirection();

			IntVector2 actualdir = controller.NextDirection();
			IntVector2 expecteddir = Vector2.right;

			Assert.AreEqual(actualdir, expecteddir);
        }
		[Test]
		public void ControllerEnqueueLeft()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.left);

			controller.NextDirection();

			IntVector2 actualdir = controller.NextDirection();
			IntVector2 expecteddir = Vector2.left;

			Assert.AreEqual(actualdir, expecteddir);
        }
		[Test]
		public void ControllerEnqueueDown()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.down);

			controller.NextDirection();

			IntVector2 actualdir = controller.NextDirection();
			IntVector2 expecteddir = Vector2.down;

			Assert.AreEqual(actualdir, expecteddir);
        }
		[Test]
		public void ControllerMultiEnqueue()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.up);
			controller.Enqueue(Vector2.down);
			controller.Enqueue(Vector2.left);
			controller.Enqueue(Vector2.right);

			controller.NextDirection();
			IntVector2 actualdir1 = controller.NextDirection();
			IntVector2 expecteddir1 = Vector2.up;

			IntVector2 actualdir2 = controller.NextDirection();
			IntVector2 expecteddir2 = Vector2.down;

			IntVector2 actualdir3 = controller.NextDirection();
			IntVector2 expecteddir3 = Vector2.left;

			IntVector2 actualdir4 = controller.NextDirection();
			IntVector2 expecteddir4 = Vector2.right;

			Assert.AreEqual(actualdir1, expecteddir1);
			Assert.AreEqual(actualdir2, expecteddir2);
			Assert.AreEqual(actualdir3, expecteddir3);
			Assert.AreEqual(actualdir4, expecteddir4);
        }
		[Test]
		public void ControllerPreviousDirection()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Enqueue(Vector2.up);

			IntVector2 actualdir1 = controller.NextDirection();
			IntVector2 expecteddir1 = Vector2.up;

			IntVector2 actualdir2 = controller.NextDirection();
			IntVector2 expecteddir2 = controller.PreviousDirection();

			Assert.AreEqual(actualdir1, expecteddir1);
			Assert.AreEqual(actualdir2, expecteddir2);
        }
		[Test]
		public void ControllerReset()
        {
			var gameObject = new GameObject();
			Controller controller = gameObject.AddComponent<Controller>();

			controller.Reset();

			IntVector2 actualdir = controller.NextDirection();
			IntVector2 expecteddir = Vector2.up;

			Assert.AreEqual(actualdir, expecteddir);
        }
    }
}
