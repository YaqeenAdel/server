import { OpenAPIRouter } from "@cloudflare/itty-router-openapi";
import { FileGetSignedUrlBatch }  from "./endpoints/fileGetSignedUrlBatch";
import { FilePutSignedUrl }  from "./endpoints/filePutSignedUrl";
// import { TaskList } from "./endpoints/taskList";
// import { TaskCreate } from "./endpoints/taskCreate";
// import { TaskFetch } from "./endpoints/taskFetch";
// import { TaskDelete } from "./endpoints/taskDelete";

export const router = OpenAPIRouter({
	docs_url: "/",
});

router.post("/api/files/batch/", FileGetSignedUrlBatch);
router.put("/api/files/", FilePutSignedUrl);

// router.get("/api/tasks/", TaskList);
// router.post("/api/tasks/", TaskCreate);
// router.get("/api/tasks/:taskSlug/", TaskFetch);
// router.delete("/api/tasks/:taskSlug/", TaskDelete);

// // 404 for everything else
// router.all("*", () =>
// 	Response.json(
// 		{
// 			success: false,
// 			error: "Route not found",
// 		},
// 		{ status: 404 }
// 	)
// );

export default {
	fetch: router.handle,
};

// import { Buffer } from "buffer";

// const decode = (str: string):string => Buffer.from(str, 'base64').toString('binary');
// const encode = (str: string):string => Buffer.from(str, 'binary').toString('base64');

// interface Env {
// 	Yaqeen: R2Bucket
// }

// function objectNotFound(objectName: string): Response {
// 	return new Response(`<html><body>R2 object "<b>${objectName}</b>" not found</body></html>`, {
// 		status: 404,
// 		headers: {
// 		'content-type': 'text/html; charset=UTF-8'
// 		}
// 	})
// }

// import { AwsClient } from "aws4fetch";

// // Check requests for a pre-shared secret
// const hasValidHeader = (request, env) => {
// 	return request.headers.get('X-Custom-Auth-Key') === env.AUTH_KEY_SECRET;
// };
  
// export default {
// 	async fetch(request: Request, env: Env): Promise<Response> {
// 		const r2 = new AwsClient({
// 			accessKeyId: env.AWS_ACCESS_KEY_ID,
// 			secretAccessKey: env.AWS_SECRET_ACCESS_KEY,
// 		  });
		  
// 		if (!hasValidHeader(request, env)) {
// 			return new Response('Forbidden', { status: 403 });
// 		}

// 		const url = new URL(request.url)
// 		const objectName = url.pathname.slice(1)
  
// 	  	console.log(`${request.method} object ${objectName}: ${request.url}`)
  
// 		if (request.method === 'GET' || request.method === 'HEAD') {
// 			if (objectName === '') {
// 				if (request.method == 'HEAD') {
// 					return new Response(undefined, { status: 400 })
// 				}
	
// 				const options: R2ListOptions = {
// 					prefix: url.searchParams.get('prefix') ?? undefined,
// 					delimiter: url.searchParams.get('delimiter') ?? undefined,
// 					cursor: url.searchParams.get('cursor') ?? undefined,
// 					// include: ['customMetadata', 'httpMetadata'],
// 				}
// 				console.log(JSON.stringify(options))
		
// 				const listing = await env.Yaqeen.list(options)
// 				return new Response(JSON.stringify(listing), {headers: {
// 					'content-type': 'application/json; charset=UTF-8',
// 				}})
// 			}
	
// 			if (request.method === 'GET') {
// 				const object = await env.Yaqeen.get(objectName, {
// 					range: request.headers,
// 					onlyIf: request.headers,
// 				})
		
// 				if (object === null) {
// 					return objectNotFound(objectName)
// 				}
		
// 				const headers = new Headers()
// 				object.writeHttpMetadata(headers)
// 				headers.set('etag', object.httpEtag)
// 				if (object.range) {
// 					headers.set("content-range", `bytes ${object.range.offset}-${object.range.end ?? object.size - 1}/${object.size}`)
// 				}

// 				const bucketName = "yaqeen";
// 				const accountId = "d6bb759ee03e071575964565d63b7c4a";
			
// 				const url = new URL(
// 				  `https://${bucketName}.${accountId}.r2.cloudflarestorage.com`
// 				);

// 				url.pathname = objectName;

// 				const signed = await r2.sign(
// 					new Request(url, {
// 					  method: "GET",
// 					}),
// 					{
// 					  aws: { signQuery: true },
// 					}
// 				  );

// 				const status = object.body ? (request.headers.get("range") !== null ? 206 : 200) : 304
// 				const headers2 = new Headers()
// 				return new Response('{ "url": "' + signed.url + '" }', {
// 					headers2,
// 					status
// 				})
// 			}
	
// 			const object = await env.Yaqeen.head(objectName)
	
// 			if (object === null) {
// 				return objectNotFound(objectName)
// 			}
	
// 			const headers = new Headers()
// 			object.writeHttpMetadata(headers)
// 			headers.set('etag', object.httpEtag)
// 			return new Response(null, {
// 				headers,
// 			})
// 		}
		
// 		if (request.method === 'PUT' || request.method == 'POST') {
// 			const object = await env.Yaqeen.put(objectName, request.body, {
// 				httpMetadata: request.headers,
// 			})

// 			return new Response(null, {
// 				headers: {
// 					'etag': object.httpEtag,
// 				}
// 			})
// 		}

// 		if (request.method === 'DELETE') {
// 			await env.Yaqeen.delete(url.pathname.slice(1))
// 			return new Response()
// 		}
	
// 		return new Response(`Unsupported method`, {
// 			status: 400
// 		})
// 	}
//   }
