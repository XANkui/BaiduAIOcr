using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace GodViewAI{

	public class ScreenShot  {

		public static IEnumerator ReadPixels(){
			yield return new WaitForEndOfFrame ();
			//读取像素
			Texture2D tex = new Texture2D(Screen.width, Screen.height);
			tex.ReadPixels(new Rect(0, 0, tex.width, tex.height),0,0);
			tex.Apply();

			//保存读取的结果
			byte[] imageBytes = tex.EncodeToPNG ();

			var result = GodViewOcr.Instance.Bankcard (imageBytes);

			Debug.Log ("Byte[] :" + result );

			yield return result;
		}
	}
}
