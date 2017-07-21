using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MapMyRideExporter
{
	public interface IMapMyRideWebsite
	{
		Task Login(string userName, string password);

		Task<IEnumerable<WorkoutSummary>> GetWorkoutsDoneInMonth(DateTime month);
	}
}
