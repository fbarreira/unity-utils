using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JustKrated.Utils
{
	// Attach this script to a game object with an image component
	// Constantly changes image's color alpha channel to give a flicker effect
	// Script based on Sinbad's LightFlickerEffect.cs found on: https://gist.github.com/sinbad/4a9ded6b00cf6063c36a4837b15df969.js
	public class ImageFlickerEffect : MonoBehaviour
	{
		[Tooltip ("External light to flicker; you can leave this null if you attach script to a light")]
		public Image image;
		[Tooltip ("Minimum random light intensity")]
		public float minIntensity = 0f;
		[Tooltip ("Maximum random light intensity")]
		public float maxIntensity = 1f;
		[Tooltip ("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
		[Range (1, 50)]
		public int smoothing = 5;

		// Continuous average calculation via FIFO queue
		// Saves us iterating every time we update, we just change by the delta
		Queue<float> smoothQueue = new Queue<float> ();
		float lastSum = 0;

		/// <summary>
		/// Reset the randomness and start again. You usually don't need to call
		/// this, deactivating/reactivating is usually fine but if you want a strict
		/// restart you can do.
		/// </summary>
		public void Reset ()
		{
			smoothQueue.Clear ();
			lastSum = 0;
		}

		private void Awake ()
		{
			if (image == null)
				image = GetComponent<Image> ();
		}

		void Start ()
		{
			smoothQueue = new Queue<float> (smoothing);
		}

		void Update ()
		{
			if (image == null)
				return;

			// pop off an item if too big
			while (smoothQueue.Count >= smoothing)
			{
				lastSum -= smoothQueue.Dequeue ();
			}

			// Generate random new item, calculate new average
			float newVal = Random.Range (minIntensity, maxIntensity);
			smoothQueue.Enqueue (newVal);
			lastSum += newVal;

			// Calculate new smoothed average
			image.color = new Color (image.color.r, image.color.g, image.color.b, lastSum / (float)smoothQueue.Count);
		}
	}
}
