# Introduction
This project aims to help you to quickly get started with a containerized client-server application on AWS ECS Fargate platform behind a public Application Load Balancer. The infrastructure creation is automated through GitHub Actions so with a little configuration and a single click you can create the whole infrastructure on your AWS account.

In this example we use .NET 6, but as we make use of containers you can develop your application using the framework of your preference.

At the end of the steps below we will have the following infrastructure in place for your project:

![aws-ecs-fargate-diagram](https://github.com/stefam/aws-ecs-fargate/assets/12499171/f5b6a301-6f59-4596-a200-635c177967f7)

Let's get started.

## Create AWS User for GitHub

### Requirements
- AWS Account and access to the Console

### 1. Create User and Add Policies
Create a new IAM User called GitHubActionsUser and add the following AWS Managed policies:
- AmazonEC2ContainerRegistryFullAccess
- AmazonECS_FullAccess
- AmazonVPCFullAccess
- AWSCloudFormationFullAccess
- ElasticLoadBalancingFullAccess
- IAMFullAccess

### 2. Create Access Keys
Under the IAM User page for the user you just created:
1. Go to **Security Credentials** tab
2. Scroll down to **Access Keys** panel
3. Click on **Create access key** in the top right corner of the panel
4. A new page will pop up, then you can select the option **Third-party service**
5. Mark the checkbox at the bottom and click next
6. Enter a name for your credentials and click **Create access key**
7. The access key and secret will be displayed on the page. Keep them in a safe place. We will need them soon

## Create AWS InfraStructure
### 1. Create GitHub Secrets
We will need to log in to AWS from GitHub securely. For that we can create secrets to store sensitive information:
1. Go to your GitHub account
2. Navigate to your repository
3. Navigate to **Settings** tab
4. Expand **Secrets and variables** menu item
5. Select sub-item **Actions**
6. Now you should be able to see the page with a button **New repository secret**
7. Create one secret named AWS_ACCESS_KEY_ID and paste the value of the Access Key we created on AWS Console
8. Create one secret named AWS_SECRET_ACCESS_KEY and paste the value of the Secret Access Key we created on AWS Console
9. Create one secret named AWS_REGION with the region id of your AWS account where you want to create the resources

### 2. Run GitHub Action to Create the Infrastructure
Now you should have all setup to start creating your infrastructure:
1. On your GitHub Repository navigate to **Actions** tab
2. Look for workflow **Create AWS Infrastructure** on left panel
3. Run this workflow and wait the process to complete

When the workflow finish you should be able to see the infrastructure created on your AWS Console.
On the AWS Console navigate to the Application Load Balancer created and and look for DNS Name property.
You should be able now to open that DNS Url in your browser and see your aplication up and running.
