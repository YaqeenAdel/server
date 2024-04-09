import { AwsClient } from 'aws4fetch';
import {
  OpenAPIRoute,
  OpenAPIRouteSchema,
  Query,
} from '@cloudflare/itty-router-openapi';

// Check requests for a pre-shared secret
const hasValidHeader = (request: Request, env: any) => {
  return request.headers.get('X-Custom-Auth-Key') === env.AUTH_KEY_SECRET;
};

export class GetNextAppointments extends OpenAPIRoute {
  static schema: OpenAPIRouteSchema = {
    tags: ['Appointments'],
    summary: 'Get next appointments',
    query: {
      cronExpression: {
        type: 'string',
        description: 'Cron expression string for calculating next appointments',
      },
      count: {
        type: 'number',
        description: 'Number of appointments to calculate',
      },
    },
    responses: {
      '200': {
        description: 'Returns the next appointments',
        schema: {
          appointments: {
            type: 'array',
            items: {
              type: 'string',
            },
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
    // const { cronExpression, count } = data.params; // Error 400 bad request

    const cronExpression = '* * * * *';
    const count = 2;

    console.log(cronExpression, count);

    const r2 = new AwsClient({
      accessKeyId: env.AWS_ACCESS_KEY_ID,
      secretAccessKey: env.AWS_SECRET_ACCESS_KEY,
    });

    if (!hasValidHeader(request, env)) {
      return new Response('Forbidden', { status: 403 });
    }

    const bucketName = 'yaqeen';
    const accountId = 'd6bb759ee03e071575964565d63b7c4a';

    const url = new URL(
      `https://${bucketName}.${accountId}.r2.cloudflarestorage.com`
    );

    // convert forEach to an async one
    let urls: any[] = [];
    console.log(`Generating a signed url for ${path}`);
    url.pathname = path;

    const signed = await r2.sign(
      new Request(url, {
        method: 'PUT',
      }),
      {
        aws: { signQuery: true },
      }
    );

    return {
      path: path,
      signed_url: signed.url,
    };
  }
}
