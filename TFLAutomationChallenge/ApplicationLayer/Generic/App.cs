namespace ApplicationLayer.Generic
{
	public class App
	{
		private static TFLWebApp _tflWebApp;

		public static TFLWebApp TflWebApp
		{
			get 
			{ 
				_tflWebApp = _tflWebApp ?? new TFLWebApp();
				return _tflWebApp; 
			}
		}
	}
}