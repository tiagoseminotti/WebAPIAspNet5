# WebAPIAspNet5
AspNet 5 WebAPI for linux tests connected on SQL Server Database

This project runs on Asp.Net 5 with Entity Framework 7 and is a test for linux VMs. 
It runs on docker and uses a SQL Server database for CRUD operations on a specific table named GspConexaoGesplan.

Step by step instructions:

1 - Create a SQL Database and run the following script:

CREATE TABLE GspConexaoGesplan
(
	idConexaoGesplan	int identity(1,1) primary key,
	dsConexaoGesplan	varchar(50) not null,
	dsServidor			varchar(100) not null,
	dsDatabase			varchar(100) null,
	dsUsuario			varchar(50) not null,
	dsSenha				varchar(100) not null,
	stTipoBanco			int not null
);

2 - Create a linux VM with docker.
http://blogs.msdn.com/b/webdev/archive/2015/01/14/running-asp-net-5-applications-in-linux-containers-with-docker.aspx

3- After installing docker, clone the repository:
git clone https://github.com/tiagoseminotti/WebAPIAspNet5.git WebAPIAspNet5
cd aspnet-service/src/AspNetService

4- Create a Dockerfile with the following content: (If you need explanation on the file, visit the link on item 2)

FROM microsoft/aspnet:1.0.0-beta4

COPY . /app

WORKDIR /app

RUN ["dnu", "restore"]

EXPOSE 5004

ENTRYPOINT ["dnx", "project.json", "kestrel"]

5- Create your docker image.
docker build -t webapiaspnet5 .

6- Run the container. (This command is going to map the port 5010 of docker to the port 80 on the VMM)
docker run -t -d -p 80:5010 webapiaspnet5
