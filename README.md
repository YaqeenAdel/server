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
