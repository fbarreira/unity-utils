using UnityEngine;

namespace JustKrated.Utils.AspectRatio
{
	// Create a instance of this scriptable object on inspector menu
	[CreateAssetMenu (fileName = "AspectRatioDatabase", menuName = "ScriptableObjects/Aspect Ratio Database", order = 1)]
	public class AspectRatioDatabase : ScriptableObject
	{
		public AspectRatio[] aspectRatios =
		{
			new AspectRatio ("16x9", new Vector2 (16, 9), 4.9f),
			new AspectRatio ("16x10", new Vector2 (16, 10), 4.9f),
			new AspectRatio ("18x9", new Vector2 (18, 9), 4.9f),
			new AspectRatio ("18.5x9", new Vector2 (18.5f, 9), 4.75f),
			new AspectRatio ("19x9", new Vector2 (19, 9), 4.6f),
			new AspectRatio ("4x3", new Vector2 (4, 3), 4.5f),
			new AspectRatio ("18x8.8", new Vector2 (18, (40/4.5f)), 4.8f),
			new AspectRatio ("19.5x9", new Vector2 (39, 18), 4.5f),
			new AspectRatio ("19x10", new Vector2 (19, 10), 4.5f),
		};
	}

}