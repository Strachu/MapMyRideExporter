using System;
using System.IO;
using CommandLine;
using CommandLine.Text;

namespace MapMyRideExporter
{
	public class CommandLineOptions
	{
		public CommandLineOptions()
		{
			EndDate = DateTime.Today;
		}

		[Option('l', "login", Required = true, HelpText = "The login to map my ride website.")]
		public string Login { get; set; }

		[Option('p', "password", Required = true, HelpText = "The password to map my ride website.")]
		public string Password { get; set; }

		[Option('s', "start-date", Required = true, HelpText = "The starting date of workout to export.")]
		public DateTime StartDate { get; set; }

		[Option('e', "end-date", HelpText = "End date of workouts to export. Today if not specified.")]
		public DateTime EndDate { get; set; }
		
		[Value(0, MetaName = "destination-path", Required = true, HelpText = "Directory to export files to.")]
		public string DestinationPath { get; set; }

		public static string GetHelpText(ParserResult<CommandLineOptions> parsingResult)
		{
			var exeName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

			var help = HelpText.AutoBuild(parsingResult);

			help.AddPreOptionsLine(" ");
			help.AddPreOptionsLine($"Usage: {exeName} [options] --login noobcake --password mycake --start-date 2011-04-12 destination_path");

			return help.ToString();
		}
	}
}
