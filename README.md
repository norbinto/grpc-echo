# grpc-echo

gRPC-Echo is a sample .NET Core gRPC Server-Client project.

`/certificates` folder contains a self-signed `.pfx` key file. (`.key`, and `.crt` files as well as the password are committed to the same repository, so they are not secure at all)

## How to build and run

`docker-compose up` in the root directory will launch the server app. Then you can run the client app separately. You'll need .NET Core runtime installed first.
