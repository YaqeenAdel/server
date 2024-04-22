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
	scheduled_time: Date;
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
					events: [JSON],
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
			try {
				let options: any = { count: next_count };

				// Check if start_time is a valid date
				if (!isNaN(Date.parse(schedule.start_time))) {
					options.startAt = new Date(schedule.start_time);
				}
		
				const nextEvents = cronjsMatcher.getFutureMatches(schedule.cron_expression, options);
		
				// Add the generated events to the allEvents array
				for (let event of nextEvents) {
					allEvents.push({
						schedule_id: schedule.schedule_id, 
						scheduled_time: new Date(event)
					});
				}
			} catch (e) {
				console.log("Error generating events: ", e);
			}
		}

		console.log("Generated events: ", allEvents)
		allEvents.sort((a, b) => a.scheduled_time.getTime() - b.scheduled_time.getTime());

		return {
			events: allEvents
		};
	}
}
