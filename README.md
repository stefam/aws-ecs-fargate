# Introduction
This project aims to help you to quickly get started with a .NET Core client-server application on AWS ECS Fargate platform behind a public Application Load Balancer in its own private subnet. The infrastructure creation is automated through GitHub Actions so with a little configuration and a single click you can create the whole infrastructure on your AWS account.

Note: .NET Core is not a limitation. As you will see by using containers you can develop your application using the framework of your preference

Below we will see a few steps you need to follow to get your environment up and running.

## Create AWS User for GitHub

### Requirements
- AWS Account and access to the Console

### 1. Create User and Add Policies
Create a new IAM User called GitHubActionsUser and add the following AWS Managed policies:
- AmazonEC2ContainerRegistryFullAccess
- AmazonECS_FullAccess
- AmazonSSMFullAccess
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
### 1. Create Secrets
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

### 2. Run GitHub Action to Create Infra
Now you should have all setup to start creating your infrastructure:
1. On your GitHub Repository navigate to **Actions** tab
2. Look for workflow **Create AWS Infrastructure** on left panel
3. Run this workflow and wait the process to complete

At the end of the workflow you should be able to see the infrastructure created on your AWS Console.
On the AWS Console navigate to the Application Load Balancer created and and look for DNS Name property.
You should be able now to open that DNS Url in your browser and see your aplication up and running.
