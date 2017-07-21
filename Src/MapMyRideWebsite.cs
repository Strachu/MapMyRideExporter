using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace MapMyRideExporter
{
	public class MapMyRideWebsite : IMapMyRideWebsite, IDisposable
	{
		private const string WebsiteUrl = "https://www.mapmyride.com";

		private readonly HttpClient mHttpClient = new HttpClient();

		public async Task Login(string userName, string password)
		{
			var json = JObject.FromObject(new
			{
				username = userName,
				password = password
			});

			var requestContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
			var response = await mHttpClient.PostAsync($"{WebsiteUrl}/auth/login", requestContent);

			if(response.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception($"Failed to login with error {response.StatusCode}!");
			}
		}

		public async Task<IEnumerable<WorkoutSummary>> GetWorkoutsDoneInMonth(DateTime month)
		{
			var result = await mHttpClient
				.GetStringAsync($"https://www.mapmyride.com/workouts/dashboard.json?month={month.Month}&year={month.Year}");

			Console.WriteLine(result);

			var json = JObject.Parse(result);

			return new WorkoutSummary[0];
		}

		public void Dispose()
		{
			mHttpClient.Dispose();
		}
	}
}
