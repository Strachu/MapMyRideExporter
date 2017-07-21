using NUnit.Framework;
using System;
using FluentAssertions;

namespace MapMyRideExporter.Tests
{
	[TestFixture]
	public class DashboardJsonParserTests
	{
		private IDashboardJsonParser _parser;

		[SetUp]
		public void SetUp()
		{
			_parser = new DashboardJsonParser();
		}
		
		[Test]
		public void ParseWorkouts()
		{
			var result = _parser.ParseWorkouts(SampleJson);

			var expectedResult = new WorkoutSummary[]
			{
				new WorkoutSummary
				{
					WorkoutDate = new DateTime(2016, 8, 25),
					WorkoutUrl = "/workout/1703314241"
				},
				new WorkoutSummary
				{
					WorkoutDate = new DateTime(2016, 8, 24),
					WorkoutUrl = "/workout/1700659904"
				},
				new WorkoutSummary
				{
					WorkoutDate = new DateTime(2016, 8, 27),
					WorkoutUrl = "/workout/1707528353"
				},
				new WorkoutSummary
				{
					WorkoutDate = new DateTime(2016, 8, 28),
					WorkoutUrl = "/workout/1709715236"
				},
				new WorkoutSummary
				{
					WorkoutDate = new DateTime(2016, 9, 02),
					WorkoutUrl = "/workout/1721324126"
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
         ""2016-08-25"":[
            {
               ""view_url"":""/workout/1703314241"",
               ""energy"":0,
               ""date"":""08/25/2016"",
               ""effort"":"""",
               ""activity_short_name"":""ride"",
               ""distance"":7.6966393996800004,
               ""name"":""Rode 7,70 km on 25.08.2016"",
               ""speed"":0.58788874119156742,
               ""activity_color"":""#B3251D"",
               ""pace"":1.7010021283502408,
               ""steps"":"""",
               ""time"":13092,
               ""activity_name"":""Bike Ride"",
               ""edit_url"":""/workout/edit/1703314241/""
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
         ""2016-08-27"":[
            {
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
         ],
         ""2016-08-28"":[
            {
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
            }
         ],
         ""2016-09-02"":[
            {
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
            }
         ]
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
