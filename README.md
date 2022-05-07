# DexLK.Microservice

# How to upload docker file to AWS
1. go to Amazon Elastic Container Registry from AWS console 
2. Click on the create repository button to create a new
	2.1 give a repository name undeter details as follow : public.ecr.aws/x5n8i3z0/XXXXXXXXXX
	2.2 other than the repostory name dont change anything, Clcik the  Create Repository button to create.
	2.3 After creating the repostory, click on the repository from the list 
	2.4 Clcik on the "View Push Commands" and follow the instruction bellow
3. open tje PowerShell using Administrator previlage 
4. Type aws configure and enter the following values from the .csv file, the csv file is downloaed soon after creating the user 
	4.1 Access key ID	
	4.2 Secret access key
	4.3 Default region name [None]
	4.4 Default output format [None]:
	Note : if your not sure about the value leave it empty, ex. Default output format,Default region name
		region can be taken from the AWS console 
5. follow the steps given in the  "View Push Commands" popup