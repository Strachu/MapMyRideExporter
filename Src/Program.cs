using System;
using CommandLine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MapMyRideExporter
{
	class MainClass
	{
		private static IMapMyRideWebsite mMapMyRide = new MapMyRideWebsite(new DashboardJsonParser());
		
		public static int Main(string[] args)
		{
			var parsingResult = new Parser(x => x.HelpWriter = null).ParseArguments<CommandLineOptions>(args);

			return parsingResult.MapResult(x => Run(x).Result, errors =>
			{
				Console.WriteLine(CommandLineOptions.GetHelpText(parsingResult));
				return 1;
			});
		}

		private static async Task<int> Run(CommandLineOptions options)
		{
			Console.WriteLine($"Logging in as {options.Login}...");
			await mMapMyRide.Login(options.Login, options.Password);
			Console.WriteLine($"Successfully logged as {options.Login}...");

			Console.WriteLine($"Retrieving workout list from {options.StartDate.ToShortDateString()} to {options.EndDate.ToShortDateString()}...");
			var workouts = (await GetAllWorkoutsToExport(options.StartDate, options.EndDate)).ToList();
			Console.WriteLine($"Retrieved {workouts.Count} workouts.");

			// TODO Download TCX

			return 0;
		}

		private static async Task<IEnumerable<WorkoutSummary>> GetAllWorkoutsToExport(DateTime startDate, DateTime endDate)
		{
			var result = new List<WorkoutSummary>();

			var currentDate = startDate;
			while(currentDate <= endDate)
			{
				var beginningOfNextMonth = new DateTime(currentDate.AddMonths(1).Year, currentDate.AddMonths(1).Month, day: 1);
				
				var workouts = await mMapMyRide.GetWorkoutsDoneInMonth(currentDate);

				var clippedWorkouts = workouts.Where(workout => 
					workout.WorkoutDate >= currentDate &&
					workout.WorkoutDate <= endDate &&
				   workout.WorkoutDate < beginningOfNextMonth); // TODO Make a test case for the case where startdate is not at the beginning of a month
				
				result.AddRange(clippedWorkouts);

				currentDate = beginningOfNextMonth;
			}

			return result;
		}
	}
}
