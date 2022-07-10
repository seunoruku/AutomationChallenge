using ApplicationLayer.Module;

namespace ApplicationLayer.Generic
{
    public class TFLWebApp
	{
		private SearchJourney _searchJourney;

		public SearchJourney SearchJourney
		{
			get 
			{
				_searchJourney = _searchJourney ?? new SearchJourney();
				return _searchJourney; 
			}
		}

	}
}
