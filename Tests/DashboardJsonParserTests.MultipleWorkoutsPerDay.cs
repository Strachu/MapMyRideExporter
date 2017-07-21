using NUnit.Framework;
using System;
using FluentAssertions;

namespace MapMyRideExporter.Tests
{
	[TestFixture]
	public class DashboardJsonParserTests_MultipleWorkoutsPerDay
	{
		private IDashboardJsonParser _parser;

		[SetUp]
		public void SetUp()
		{
			_parser = new DashboardJsonParser();
		}
		
		[Test]
		public void ParseWorkouts_HandlesMultipleWorkoutsPerDay()
		{
			var result = _parser.ParseWorkouts(SampleJson);

			var expectedResult = new WorkoutSummary[]
			{
				new WorkoutSummary
				{
					WorkoutId = "1700659904",
					WorkoutDate = new DateTime(2016, 8, 24),
				},
				new WorkoutSummary
				{
					WorkoutId = "2187048605",
					WorkoutDate = new DateTime(2017, 5, 12),
				},
				new WorkoutSummary
				{
					WorkoutId = "2187997814",
					WorkoutDate = new DateTime(2017, 5, 12),
				},
				new WorkoutSummary
				{
					WorkoutId = "2188224920",
					WorkoutDate = new DateTime(2017, 5, 12),
				}
			};

			result.ShouldBeEquivalentTo(expectedResult);
		}

		private const string SampleJson = @"{
   ""workout_data"":{
      ""week_stats"":[
         {
            ""distance"":0,
            ""change"":""No Change""

			},
         {
            ""distance"":0,
            ""change"":""No Change""
         },
         {
            ""distance"":43.650000000000006,
            ""change"":""Good Job!""
         },
         {
            ""distance"":27.289999999999999,
            ""change"":""-37%""
         },
         {
            ""distance"":0,
            ""change"":""-100%""
         }
      ],
      ""totals"":{
         ""hours"":40185,
         ""distance"":43.650000000000006,
         ""hardest"":null,
         ""steps"":0,
         ""longest"":{
            ""view_url"":""/workout/1709715236"",
            ""energy"":0,
            ""date"":""08/28/2016"",
            ""effort"":"""",
            ""activity_short_name"":""ride"",
            ""distance"":9.2747299392000002,
            ""name"":""Rode 9,27 km on 28.08.2016"",
            ""speed"":0.63656348244337679,
            ""activity_color"":""#B3251D"",
            ""pace"":1.5709352288975378,
            ""steps"":"""",
            ""time"":14570,
            ""activity_name"":""Bike Ride"",
            ""edit_url"":""/workout/edit/1709715236/""
         },
         ""energy"":0,
         ""workouts"":4,
         ""farthest"":{
            ""view_url"":""/workout/1707528353"",
            ""energy"":0,
            ""date"":""08/27/2016"",
            ""effort"":"""",
            ""activity_short_name"":""ride"",
            ""distance"":15.00999743232,
            ""name"":""Rode 15,01 km on 27.08.2016"",
            ""speed"":3.1753749592384177,
            ""activity_color"":""#B3251D"",
            ""pace"":0.31492343828265251,
            ""steps"":"""",
            ""time"":4727,
            ""activity_name"":""Bike Ride"",
            ""edit_url"":""/workout/edit/1707528353/""
         }
      },
      ""week_totals"":[
         {
            ""distance"":0,
            ""farthest"":null,
            ""energy"":0,
            ""hours"":0,
            ""hardest"":null,
            ""steps"":0,
            ""longest"":null,
            ""workouts"":0
         },
         {
            ""distance"":0,
            ""farthest"":null,
            ""energy"":0,
            ""hours"":0,
            ""hardest"":null,
            ""steps"":0,
            ""longest"":null,
            ""workouts"":0
         },
         {
            ""distance"":0,
            ""farthest"":null,
            ""energy"":0,
            ""hours"":0,
            ""hardest"":null,
            ""steps"":0,
            ""longest"":null,
            ""workouts"":0
         },
         {
            ""distance"":43.650000000000006,
            ""farthest"":{
               ""view_url"":""/workout/1707528353"",
               ""energy"":0,
               ""date"":""08/27/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":15.00999743232,
               ""name"":""Rode 15,01 km on 27.08.2016"",
               ""speed"":3.1753749592384177,
               ""activity_color"":""#B3251D"",
               ""pace"":0.31492343828265251,
               ""steps"":"""",
               ""time"":4727,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1707528353/""
            },
            ""energy"":0,
            ""hours"":40185,
            ""hardest"":{
               ""view_url"":""/workout/1700659904"",
               ""energy"":0,
               ""date"":""08/24/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":11.674149189120001,
               ""name"":""Rode 11,67 km on 24.08.2016"",
               ""speed"":1.4974537184607495,
               ""activity_color"":""#B3251D"",
               ""pace"":0.66780027166910505,
               ""steps"":"""",
               ""time"":7796,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1700659904/""
            },
            ""steps"":0,
            ""longest"":{
               ""view_url"":""/workout/1709715236"",
               ""energy"":0,
               ""date"":""08/28/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":9.2747299392000002,
               ""name"":""Rode 9,27 km on 28.08.2016"",
               ""speed"":0.63656348244337679,
               ""activity_color"":""#B3251D"",
               ""pace"":1.5709352288975378,
               ""steps"":"""",
               ""time"":14570,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1709715236/""
            },
            ""workouts"":4
         },
         {
            ""distance"":27.289999999999999,
            ""farthest"":{
               ""view_url"":""/workout/1721324126"",
               ""energy"":0,
               ""date"":""09/02/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":27.290450880000002,
               ""name"":""Rode 27,29 km on 02.09.2016"",
               ""speed"":3.3691914666666669,
               ""activity_color"":""#B3251D"",
               ""pace"":0.29680711526595344,
               ""steps"":"""",
               ""time"":8100,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1721324126/""
            },
            ""energy"":0,
            ""hours"":8100,
            ""hardest"":{
               ""view_url"":""/workout/1721324126"",
               ""energy"":0,
               ""date"":""09/02/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":27.290450880000002,
               ""name"":""Rode 27,29 km on 02.09.2016"",
               ""speed"":3.3691914666666669,
               ""activity_color"":""#B3251D"",
               ""pace"":0.29680711526595344,
               ""steps"":"""",
               ""time"":8100,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1721324126/""
            },
            ""steps"":0,
            ""longest"":{
               ""view_url"":""/workout/1721324126"",
               ""energy"":0,
               ""date"":""09/02/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":27.290450880000002,
               ""name"":""Rode 27,29 km on 02.09.2016"",
               ""speed"":3.3691914666666669,
               ""activity_color"":""#B3251D"",
               ""pace"":0.29680711526595344,
               ""steps"":"""",
               ""time"":8100,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1721324126/""
            },
            ""workouts"":1
         },
         {
            ""distance"":0,
            ""farthest"":null,
            ""energy"":0,
            ""hours"":0,
            ""hardest"":null,
            ""steps"":0,
            ""longest"":null,
            ""workouts"":0
         }
      ],
      ""weeks"":6,
      ""workouts"":{
         ""2017-05-12"":[
            {
               ""view_url"":""/workout/2187048605"",
               ""energy"":0,
               ""date"":""05/12/2017"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":12.131910996480002,
               ""name"":""Rode 12,13 km on 12.05.2017"",
               ""speed"":4.9558459952941192,
               ""activity_color"":""#B3251D"",
               ""pace"":0.2017818957549451,
               ""steps"":"""",
               ""time"":2448,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/2187048605/""
            },
            {
               ""view_url"":""/workout/2187997814"",
               ""energy"":0,
               ""date"":""05/12/2017"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":6.8051593843200004,
               ""name"":""Rode 6,81 km on 12.05.2017"",
               ""speed"":3.7639155886725666,
               ""activity_color"":""#B3251D"",
               ""pace"":0.26568077217498748,
               ""steps"":"""",
               ""time"":1808,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/2187997814/""
            },
            {
               ""view_url"":""/workout/2188224920"",
               ""energy"":0,
               ""date"":""05/12/2017"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":6.7795547212800011,
               ""name"":""Rode 6,78 km on 12.05.2017"",
               ""speed"":4.4661098295652177,
               ""activity_color"":""#B3251D"",
               ""pace"":0.22390851057448163,
               ""steps"":"""",
               ""time"":1518,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/2188224920/""
            }
         ],
         ""2016-08-24"":[
            {
               ""view_url"":""/workout/1700659904"",
               ""energy"":0,
               ""date"":""08/24/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":11.674149189120001,
               ""name"":""Rode 11,67 km on 24.08.2016"",
               ""speed"":1.4974537184607495,
               ""activity_color"":""#B3251D"",
               ""pace"":0.66780027166910505,
               ""steps"":"""",
               ""time"":7796,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1700659904/""
            }
         ],
      },
      ""day_totals"":[
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":7796,
            ""distance"":11.67,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":13092,
            ""distance"":7.7000000000000002,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":4727,
            ""distance"":15.01,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":14570,
            ""distance"":9.2699999999999996,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         },
         {
            ""hours"":0,
            ""distance"":0.0,
            ""energy"":0,
            ""steps"":0
         }
      ],
      ""qs_activity_dates"":[


		]
   },
   ""plan_data"":{
      ""training_plans"":{

      }
   }
}";

	}
}
