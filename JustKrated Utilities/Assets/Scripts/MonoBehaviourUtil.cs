using System;
using UnityEngine;

namespace JustKrated.Utils
{
	// Attach this on a game object or derive from it.
	// This utility allows you to invoke methods using the action directly instead of a methodName.
	// Improved debbuging allowing you to switch on/off and filtering messages with tags.
	public class MonoBehaviourUtil : MonoBehaviour
	{
		[Header ("MONO PARAMETERS")]

		[Tooltip ("Shows debug messages on the console.")]
		public bool debugEnabled;

		[SerializeField]
		[Tooltip ("TAG for identifying messages on the console.")]
		protected string debugTag = "MONO-UTIL";

		#region * INVOKING *

		/// <summary>
		/// Invokes the action in <c>time</c> seconds.
		/// </summary>
		protected void Invoke (Action action, float time)
		{
			Invoke (action.Method.Name, time);
		}

		/// <summary>
		/// Invokes the action in <c>time</c> seconds, then repeatedly every <c>repeatRate</c> seconds.
		/// </summary>
		protected void InvokeRepeating (Action action, float repeatRate, float time = 0f)
		{
			InvokeRepeating (action.Method.Name, repeatRate, time);
		}

		#endregion

		#region * LOGGING *

		/// <summary>
		/// Logs a message to Unity Console.
		/// </summary>
		protected void Log (object message, bool overrideDebug = false)
		{
			if (debugEnabled || overrideDebug) Debug.Log (debugTag + ": " + message);
		}

		/// <summary>
		/// Logs a formatted message to Unity Console.
		/// </summary>
		protected void LogFormat (string format, params object[] args)
		{
			if (debugEnabled) Debug.LogFormat (debugTag + ": " + format, args);
		}

		/// <summary>
		/// Logs a warning message to Unity Console.
		/// </summary>
		protected void LogWarning (object message, bool overrideDebug = false)
		{
			if (debugEnabled || overrideDebug) Debug.LogWarning (debugTag + ": " + message);
		}

		/// <summary>
		/// Logs a formatted warning message to Unity Console.
		/// </summary>
		protected void LogWarningFormat (string format, params object[] args)
		{
			if (debugEnabled) Debug.LogWarningFormat (debugTag + ": " + format, args);
		}

		/// <summary>
		/// Logs a error message to Unity Console.
		/// </summary>
		protected void LogError (object message, bool overrideDebug = false)
		{
			if (debugEnabled || overrideDebug) Debug.LogError (debugTag + ": " + message);
		}

		/// <summary>
		/// Logs a formatted error message to Unity Console.
		/// </summary>
		protected void LogErrorFormat (string format, params object[] args)
		{
			if (debugEnabled) Debug.LogErrorFormat (debugTag + ": " + format, args);
		}

		#endregion
	}

}