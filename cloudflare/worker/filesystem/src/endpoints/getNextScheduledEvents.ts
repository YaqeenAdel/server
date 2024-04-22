import { AwsClient } from "aws4fetch";
import { Task } from "../types";
import {
	OpenAPIRoute,
	OpenAPIRouteSchema,
	Int,
	DataOf
} from "@cloudflare/itty-router-openapi";
import {parse} from '@datasert/cronjs-parser';
import * as cronjsMatcher from '@datasert/cronjs-matcher';
import {z} from 'zod'

// Check requests for a pre-shared secret
const hasValidHeader = (
	request: Request,
	env: any,
) => {
	return request.headers.get('X-Custom-Auth-Key') === env.AUTH_KEY_SECRET;
};

export class Schedule {
	schedule_id: number;
	cron_expression: String;
	start_time: Date;
}

export class Output {
	schedule_id: number;
	time: Date;
}
  
export class GetNextScheduledEvents extends OpenAPIRoute {
	static schema: OpenAPIRouteSchema = {
		tags: ["schedules"],
		summary: "Gets the next scheduled events for a schedule",
		requestBody: z.object({
			schedules: z.object({
				schedule_id: z.number(),
				cron_expression: z.string(),
				start_time: z.string()
			}).array(),
			next_count: z.number()
		  }),
		responses: {
			"200": {
				description: "Returns a list of next schedules",
				schema: {
					result: [JSON],
				},
			},
		},
	};

	async handle(
		request: Request,
		env: any,
		context: any,
		data: any
	) {
		if (!hasValidHeader(request, env)) {
			return new Response('Forbidden', { status: 403 });
		}

		console.log("Getting next scheduled events for " + JSON.stringify(data.body));
		// Retrieve the validated parameters
		const { schedules, next_count } = data.body;

		// Initialize an array to hold all events
		let allEvents: Output[] = [];

		// Iterate over each schedule
		for (let schedule of schedules) {
			if (schedule === undefined) {
				continue;
			}

			console.log("generating events for schedule: ", JSON.stringify(schedule));
			const nextEvents = cronjsMatcher.getFutureMatches(schedule.cron_expression, 
				{
					startAt: schedule.start_time,
					count: next_count
				});

			// Add the generated events to the allEvents array
			for (let event of nextEvents) {
				allEvents.push({
					schedule_id: schedule.schedule_id, 
					time: new Date(event)
				});
			}
		}

		console.log("Generated events: ", allEvents)
		allEvents.sort((a, b) => a.time.getTime() - b.time.getTime());

		return {
			result: allEvents
		};
	}
}
