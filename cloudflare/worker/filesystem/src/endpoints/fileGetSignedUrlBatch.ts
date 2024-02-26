import { AwsClient } from "aws4fetch";
import { Task } from "../types";
import {
	OpenAPIRoute,
	OpenAPIRouteSchema,
	Query,
} from "@cloudflare/itty-router-openapi";

// Check requests for a pre-shared secret
const hasValidHeader = (
	request: Request,
	env: any,
) => {
	return request.headers.get('X-Custom-Auth-Key') === env.AUTH_KEY_SECRET;
};
  
export class FileGetSignedUrlBatch extends OpenAPIRoute {
	static schema: OpenAPIRouteSchema = {
		tags: ["Files"],
		summary: "Get signed URLs for a batch of files",
		requestBody: {
			paths: [String]
		},
		responses: {
			"200": {
				description: "Returns a list of signed urls",
				schema: {
					result: {
						urls: [JSON],
					},
				},
			},
		},
	};

	async handle(
		request: Request,
		env: any,
		context: any,
		data: Record<string, any>
	) {
		// Retrieve the validated parameters
		const { paths } = data.body;

		const r2 = new AwsClient({
			accessKeyId: env.AWS_ACCESS_KEY_ID,
			secretAccessKey: env.AWS_SECRET_ACCESS_KEY,
		  });
		  
		if (!hasValidHeader(request, env)) {
			return new Response('Forbidden', { status: 403 });
		}

		const bucketName = "yaqeen";
		const accountId = "d6bb759ee03e071575964565d63b7c4a";
	
		const url = new URL(
		  `https://${bucketName}.${accountId}.r2.cloudflarestorage.com`
		);

		// convert forEach to an async one
		let urls: any[] = [];

		console.log(`Generating signed urls for ${paths.length} paths`);

		let expanded_paths = paths.flatMap((path: string) => {
			return path.split(",");
		});

		for (const path of expanded_paths) {
			console.log(`Generating a signed url for ${path}`);
			url.pathname = path;

			const signed = await r2.sign(
				new Request(url, {
					method: "GET",
				}),
				{
					aws: { signQuery: true },
				}
			);

			urls.push({ 
				"path": path,
				"signed_url": signed.url 
			});
		};

		return {
			urls: urls,
		};
	}
}
