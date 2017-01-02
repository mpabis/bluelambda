# Test AWS Lambda code in .NET Core

## Install [WS CLI](https://aws.amazon.com/cli)

## Configure AWS access
    aws configure

## Create S3 bucket

    aws s3 mb s3://bluelambda

Replace **bluelambda** with your unique bucket name

## Build the project
    dotnet restore
    dotnet build
    dotnet publish
    
## Pack
    aws cloudformation package --template-file bluelambda.yaml --output-template-file serverless-output.yaml --s3-bucket bluelambda

## Deploy to S3
    aws cloudformation deploy --template-file serverless-output.yaml --stack-name bluelambda --capabilities CAPABILITY_IAM
