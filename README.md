# Server Repository

This repository contains the server components, including the database, API, Docker configurations, and more.

## Technologies Used

- Auth0 for authentication and authorization.
- .NET Core 7.0 for building the API.

## Installation

To install and try the API locally, follow these steps:

```bash
# Clone the repository
git clone <repository_url>

# Navigate to the project directory
cd server

# Build the Docker image for development
docker build -t your_image_name -f Dockerfile.dev .

# Run the Docker container for development
docker run -p 80:80 your_image_name
```
## Usage

Once the Docker container is up and running, you can interact with the API using the provided endpoints.

## Contributing

Pull requests and contributions are welcome. Please feel free to fork the repository and submit your changes.

### APIs

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/9504554-69c7cb0f-cda8-42cc-9c2f-644070e955f6?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D9504554-69c7cb0f-cda8-42cc-9c2f-644070e955f6%26entityType%3Dcollection%26workspaceId%3Dd0238384-7631-4418-952b-9916be81c334)

### Database Schema Updates

We leverage neon.tech for a serverless Postgres hosting. One of the advantages of neon.tech is DB branching where we can branch a DB off main and apply the migrations to test them before applying them to the main branch.

We have implemented CICD for safe Schema evolution. Please strictly follow this procedure to ensure safe migrations.

#### Schema Updates:

1. Create a local branch `git checkout -b "my-update"`. One caveat here is you must use a branch name that isn't in the existing list of migrations. Check the YaqeelDal/Migrations directory for a list of existing migrations.
2. Make an update to YaqeenDAL/Models directory
3. Commit and push your branch.
4. A github actions workflow will run to inspect your change and generate a new migration if needed. If one is generated, it'll get committed to the same branch.
   ![image](https://github.com/YaqeenAdel/server/assets/27159/8ca79726-cff6-4c25-84ae-20c92552d4c4)
5. Once that's ready, [a job will be pending](https://github.com/YaqeenAdel/server/actions/runs/6385570704/job/17330619028) to deploy your change to a new neon.tech branch. You must approve this job manually every time.
6. Once it succeeds, [a new job will be queued](https://github.com/YaqeenAdel/server/actions/runs/6385570704/job/17330681518) to delete that neon.tech branch. Don't approve it just yet!
7. Login to neon.tech and visually verify your change (look at the tables, columns, types... whatever you intended to change)
8. Once confident, approve the second job to delete your neon.tech change.
9. It's safe to iterate on this multiple times. If you make a subsequent change to the branch, the workflow will start from a clean slate (branch off main) and apply migrations that way. So iterating on your PR is safe and will only generate a single Migration.
10. Once you commit your change and push it to main, [another job will get queued](https://github.com/YaqeenAdel/server/actions/runs/6385844822) to apply the migrations to the main production database. Approve that and monitor it for completion!
