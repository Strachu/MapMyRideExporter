using System;
using System.Collections.Generic;
namespace MapMyRideExporter
{
	public interface IDashboardJsonParser
	{
		IEnumerable<WorkoutSummary> ParseWorkouts(string inputJson);
	}
}
