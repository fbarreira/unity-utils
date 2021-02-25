using UnityEngine;
using UnityEngine.UI;

namespace JustKrated.Utils
{
	// Simple class for opening websites on UI
	[RequireComponent (typeof (Button))]
	public class LinkOpener : MonoBehaviour
	{
		[Tooltip ("URL of website to open. Ex: https://google.com")]
		public string url = "";

		Button button;

		private void Awake ()
		{
			button = GetComponent<Button> ();
		}

		private void OnEnable ()
		{
			button.onClick.AddListener (GoToLink);
		}

		private void OnDisable ()
		{
			button.onClick.RemoveListener (GoToLink);
		}

		public void GoToLink ()
		{
			if (url != "")
				Application.OpenURL (url);
			else
				Debug.LogWarning ("Please provide a URL.");
		}
	}
}