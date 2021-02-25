using UnityEngine;

namespace JustKrated.Utils.AspectRatio
{

	[System.Serializable]
	public struct AspectRatio
	{
		public string name;
		public Vector2 aspectRatio;
		public float size;

		public AspectRatio (string name, Vector2 aspectRatio, float size)
		{
			this.name = name;
			this.aspectRatio = aspectRatio;
			this.size = size;
		}

		public float Ratio
		{
			get
			{
				return aspectRatio.x / aspectRatio.y;
			}
		}

		public bool IsApproximately (float value)
		{
			return Mathf.Approximately (Ratio, value);
		}
	}

}