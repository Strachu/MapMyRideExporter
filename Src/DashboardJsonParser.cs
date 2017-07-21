﻿using System;
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

			return workouts.Cast<JProperty>().Select(x => new WorkoutSummary
			{
				WorkoutDate = DateTime.Parse(x.Name, CultureInfo.InvariantCulture),
				WorkoutUrl = x.Value[0]["view_url"].ToString()
			});
		}
	}
}