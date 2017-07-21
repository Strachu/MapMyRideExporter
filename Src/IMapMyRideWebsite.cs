using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
namespace MapMyRideExporter
{
	public interface IMapMyRideWebsite
	{
		Task Login(string userName, string password);

		Task<IEnumerable<WorkoutSummary>> GetWorkoutsDoneInMonth(DateTime month);

		Task<Stream> DownloadTcxFile(WorkoutSummary workout);
	}
}
