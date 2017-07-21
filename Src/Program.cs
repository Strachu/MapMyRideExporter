using System;
using CommandLine;
using System.Threading.Tasks;

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
			await mMapMyRide.Login(options.Login, options.Password);
			
			for(var currentDate = options.StartDate; currentDate <= options.EndDate; currentDate = currentDate.AddMonths(1))
			{
				var workouts = await mMapMyRide.GetWorkoutsDoneInMonth(currentDate);

				// TODO Download TCX

				// TODO Filter out partial months
			}

			return 0;
		}
	}
}
