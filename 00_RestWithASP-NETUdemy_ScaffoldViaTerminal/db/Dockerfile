FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithASP-NETUdemy/db/migrations/ /home/database/
COPY ./RestWithASP-NETUdemy/db/dataset/ /home/database/
COPY ./RestWithASP-NETUdemy/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh

RUN chmod +x /docker-entrypoint-initdb.d/init_database.sh
