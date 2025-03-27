FROM mysql:5.7.22
EXPOSE 3306
COPY ./RESTWithASP-NET/db/migrations/ /home/database/
COPY ./RESTWithASP-NET/db/dataset/ /home/database/
COPY ./RESTWithASP-NET/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh