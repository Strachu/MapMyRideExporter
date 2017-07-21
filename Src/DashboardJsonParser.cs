using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Globalization;

namespace MapMyRideExporter
{
	public class DashboardJsonParser : IDashboardJsonParser
	{
		public IEnumerable<WorkoutSummary> ParseWorkouts(string inputJson)
		{
			var root = JObject.Parse(inputJson);
			var workout_data = root["workout_data"];
			var workouts = workout_data["workouts"];

			return workouts.Cast<JProperty>().SelectMany(x => x.Value.Select(y => new WorkoutSummary
			{
				WorkoutId = ExtractIdFromUrl(y["view_url"].ToString()),
				WorkoutDate = DateTime.Parse(x.Name, CultureInfo.InvariantCulture),
			}));
		}

		private string ExtractIdFromUrl(string url)
		{
			var tokens = url.Split('/');

			return tokens.Last();
		}
	}
}
