using UnityEngine;

namespace JustKrated.Utils.AspectRatio
{
	public class CameraResizer : MonoBehaviour
	{
#pragma warning disable CS0649
		// Select the scriptable object on inspector
		[SerializeField]
		private AspectRatioDatabase database;
#pragma warning restore CS0649

		private void Awake ()
		{
			if (database == null)
				return;

			SetAspectRatio ();
		}

		private void SetAspectRatio ()
		{
			Camera cam = GetComponent<Camera> ();
			float aspectRatio = cam.aspect;

			foreach (AspectRatio ratio in database.aspectRatios)
			{
				if (Delta (aspectRatio, ratio.Ratio))
				{
					Debug.LogFormat ("{0}: {1}", ratio.name, ratio.Ratio);
					cam.orthographicSize = ratio.size;
					return;
				}
			}

			Debug.LogFormat ("unrecognized aspect ratio: {0}", aspectRatio);
		}

		private bool Delta (float screenRatio, float baseRatio)
		{
			return (Mathf.Abs (screenRatio - baseRatio) <= 0.001f);
		}
	}
}
