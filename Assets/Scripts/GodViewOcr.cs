using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baidu.Aip.Ocr;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace GodViewAI{

	/// <summary>
	/// 文字识别类型，Ocr type.
	/// </summary>
	public enum OcrType{
		Bankcard,			//银行卡
		GeneralBasic,		//文字识别
		BusinessLicense,	//营业执照
		DrivingLicense,		//驾驶证
		Idcard,				//身份证
		LicensePlate,		//车牌		


	}

	public class GodViewOcr {

		#region 基本设置和初始化

		// 设置APPID/AK/SK
		private const string APP_ID = "11495803";
		private const string API_KEY = "hlwI4DgE5tj2Si49qxbeeDAE";
		private const string SECRET_KEY = "6TahhCDFQO1CvZiGhHmYO72cjtUjoPTC";

		public Ocr client;

		private static GodViewOcr _instance;
		public static GodViewOcr Instance{
			get{ 
				if(_instance == null){
					_instance = new GodViewOcr ();
					Debug.Log ("new GodViewOcr ()");
				}

				return _instance;
			}
		}

		private GodViewOcr(){
			client = new Ocr (API_KEY, SECRET_KEY);
		}

		#endregion


		#region 文字识别

		/// <summary>
		/// Generals the basic.
		/// </summary>
		/// <returns>The basic.</returns>
		/// <param name="imageFilename">Image filename.</param>
		public JObject GeneralBasic(string imageFilename){
			
			JObject result = null;
				
			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.GeneralBasic(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		/// <summary>
		/// Generals the basic.
		/// </summary>
		/// <returns>The basic.</returns>
		/// <param name="imageBytes">Image bytes.</param>
		public JObject GeneralBasic(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.GeneralBasic(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 银行卡识别

		public JObject Bankcard(string imageFilename){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Bankcard(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject Bankcard(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Bankcard(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 营业执照识别

		public JObject BusinessLicense(string imageFilename){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.BusinessLicense(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject BusinessLicense(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.BusinessLicense(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 驾驶证识别

		public JObject DrivingLicense(string imageFilename){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.DrivingLicense(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject DrivingLicense(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.DrivingLicense(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 身份证识别

		public JObject Idcard(string imageFilename, string idCardSide = "front"){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Idcard(image, idCardSide);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject Idcard(byte[] imageBytes, string idCardSide = "front"){
			JObject result = null;

			var options = new Dictionary<string, object>{
				{"detect_direction", "true"},
				{"detect_risk", "false"}
			};

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Idcard(image, idCardSide, options);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 车牌识别

		public JObject LicensePlate(string imageFilename){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.LicensePlate(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject LicensePlate(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.LicensePlate(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		#endregion

		#region 通用票据识别

		public JObject Receipt(string imageFilename){

			JObject result = null;

			if(imageFilename != null){
				var image = File.ReadAllBytes(imageFilename);
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Receipt(image);

				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}

			}

			return result;
		}

		public JObject Receipt(byte[] imageBytes){
			JObject result = null;

			if(imageBytes != null){
				var image = imageBytes;
				// 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
				try{
					result = client.Receipt(image);
				}catch(Exception e){
					Debug.Log ("异常:" + e);
				}


			}

			return result;
		}

		#endregion
	}

}
