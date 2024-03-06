using Amazon.CDK;
using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.S3;
using Constructs;

namespace HyperscapeCdnCdk
{
    public class HyperscapeCdnCdkStack : Stack
    {
        internal HyperscapeCdnCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Create an S3 bucket for your content
            var bucket = new Bucket(this, "hyperscape-cdn", new BucketProps
            {
                Versioned = true,
                PublicReadAccess = false,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL
            });

            // Create an OAI for CloudFront
            var oai = new OriginAccessIdentity(this, "HyperscapeCdnOai", new OriginAccessIdentityProps
            {
                Comment = "OAI for Hyperscape CDN CloudFront Distribution"
            });

            // Grant read access to the bucket from the OAI
            bucket.GrantRead(oai);

            // Create a CloudFront distribution that uses the OAI
            new CloudFrontWebDistribution(this, "HyperscapeCdnDistribution", new CloudFrontWebDistributionProps
            {
                OriginConfigs = new ISourceConfiguration[]
                {
                    new SourceConfiguration
                    {
                        S3OriginSource = new S3OriginConfig
                        {
                            S3BucketSource = bucket,
                            OriginAccessIdentity = oai
                        },
                        Behaviors = new IBehavior[] { new Behavior { IsDefaultBehavior = true } }
                    }
                }
            });
        }
    }
}
