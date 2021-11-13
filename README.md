# Projeto do [desafio 04](https://github.com/he4rtlabs/he4rtlabs-challenges-04) da He4rt Labs

### Requirements:
- **Docker** and **Docker-Compose** installed
- **Docker Daemon** running (e.g **sudo systemctl start docker.service** on Linux Based Systems)

### Running the application
- Enter the application main directory **(Where the docker-compose.yml file is)**
- **docker-compose up -d --build**
- **docker ps -a** to check if containers are running
- **docker logs *"container id or name"*** to see the container logs
- **docker exec -it *"container name"* /bin/bash** to get a interactive shell in the specified container.

### Open the API on Swagger
- API is by default hosted in **http://localhost:44300**


### Postman Collection
- You can import the **JSON** in the **Postman-Collection** directory to your running Postman account for viewing the API requests

### Database
- Docker will create a MYSQL image in a container with the **port 3308** exposed
- Can use any viewer of preference that **supports MYSQL databases**

#### To connect to the database:

- **Hostname:** localhost
- **Port:** 3308
- **Username:** docker
- **Password:** docker

#### Access Front-End 

- Hosted in **http://localhost:80**

#### User and Password for log in
- By default when successfully starting the application in development mode, it will be created a default admin user for a standard authenticated login
- Login: **adminuser@mail.com**
- Password: **admin123**
