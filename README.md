# Hyperscape CDN with CDK

This is a Visual Studio project that builds a secure CloudFront distribution with AWS CDK.  It uses a protected S3 bucket to host the assets.  CloudFront is using Origin Access Identity (OAI) so the bucket cannot be accessed independently of CloudFront.

The `cdk.json` file tells the CDK Toolkit how to execute the app.

It uses the [.NET CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute the project.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template
